using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System;

public class GokuMediator : Mediator
{
    [Inject]
    public GokuView View { get; set; }

    [Inject]
    public InputSignal InputSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        InputSignal.AddListener(OnInput);
    }

    private void OnInput(InputSignal.Key key, InputSignal.State state)
    {
        if (state == InputSignal.State.Down)
        {
            if (key == InputSignal.Key.Up)
            {
                View.MoveUp();
            } else if (key == InputSignal.Key.Down)
            {
                View.MoveDown();
            }
        }
        else if (state == InputSignal.State.Up)
        {
            if ((key == InputSignal.Key.Up || key == InputSignal.Key.Down))
            {
                View.ResetMove();
            }
        }

        
    }
}
