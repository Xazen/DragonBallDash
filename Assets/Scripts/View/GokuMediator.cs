using UnityEngine;
using System.Collections;
using strange.extensions.mediation.impl;
using System;

public class GokuMediator : Mediator
{
    [Inject]
    public IGameModel GameModel { get; set; }

    [Inject]
    public GokuView View { get; set; }

    [Inject]
    public InputSignal InputSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        GameModel.MaxLive = 5;
        GameModel.Reset();

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

            if (key == InputSignal.Key.Action)
            {
                View.Attack();
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

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == Tags.ENEMY || col.gameObject.tag == Tags.ENEMY_PROJECTILE)
        {
            GameModel.DecreaseLive();
            if (View.Lifebar != null)
            {
                View.Lifebar.DecreaseHealth();
            }

            if (GameModel.IsDead())
            {
                View.Die();
            }
            else
            {
                View.Hurt();
            }
        }
    }
}
