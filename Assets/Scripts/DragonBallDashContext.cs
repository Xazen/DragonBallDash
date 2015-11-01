/// The Context is where all the magic really happens.
/// ===========
/// Other than copying the constructors, all you really need to do when you create
/// your context is override Context or one of its subclasses, then set up
/// your list of mappings.
/// 
/// In an MVCSContext, like the one we're using, there are three types of
/// available mappings:
/// 1. Dependency Injection - Bind your dependencies to injectionBinder.
/// 2. View/Mediator Binding - Bind MonoBehaviours on your GameObjects to Mediators that speak to the rest of the app
/// 3. Event Binding - Bind Events to any/all of the following:
/// 		- Event/Method Binding -	Firing the event will trigger the method(s).
/// 		- Event/Command Binding -	Firing the event will instantiate the Command(s) and run its Execute() method.
/// 		- Event/Sequence Binding -	Firing the event will instantiate a Command(s), run its Execute() method, and,
/// 									unless the sequence is interrupted, fire each subsequent Command until the
/// 									sequence is complete.

using System;
using UnityEngine;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.dispatcher.eventdispatcher.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;


public class DragonBallDashContext : MVCSContext
{
    public DragonBallDashContext(MonoBehaviour view) : base(view)
    {
    }

    public DragonBallDashContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
    {
    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    // Override Start so that we can fire the StartSignal 
    override public IContext Start()
    {
        base.Start();
        StartSignal startSignal = (StartSignal)injectionBinder.GetInstance<StartSignal>();
        startSignal.Dispatch();
        return this;
    }

    protected override void mapBindings()
    {
        //Injection binding.
        //Map a mock model and a mock service, both as Singletons
        injectionBinder.Bind<ILiveModel>().To<LiveModel>();

        //View/Mediator binding
        mediationBinder.Bind<GokuView>().To<GokuMediator>();

        //Event/Command binding
        //commandBinder.Bind(ExampleEvent.REQUEST_WEB_SERVICE).To<CallWebServiceCommand>();
        commandBinder.Bind<StartSignal>().To<StartCommand>().Once ();

        //The START event is fired as soon as mappings are complete.
        injectionBinder.Bind<InputSignal>().ToSingleton();

    }
}

