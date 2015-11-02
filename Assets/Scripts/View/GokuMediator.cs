﻿using UnityEngine;
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

    [Inject]
    public DBAquiredSignal DBAquiredSignal { get; set; }

    public override void OnRegister()
    {
        base.OnRegister();

        GameModel.MaxLive = 7;
        GameModel.Reset();

        InputSignal.AddListener(OnInput);
        DBAquiredSignal.AddListener(OnDragonBallAquired);
    }

    private void OnDragonBallAquired(string obj)
    {
        if (obj == Tags.DB_7)
        {
            GameModel.IncreaseDragonBall();
            if (GameModel.DragonBall == 7)
            {
                View.Win();
            }
        }
    }

    private void OnInput(InputSignal.Key key, InputSignal.State state)
    {
        if (state == InputSignal.State.Down)
        {
            if (key == InputSignal.Key.Up && !GameModel.IsDead())
            {
                View.MoveUp();
            } else if (key == InputSignal.Key.Down && !GameModel.IsDead())
            {
                View.MoveDown();
            }

            if (key == InputSignal.Key.Action && !GameModel.IsDead())
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
