using UnityEngine;
using System.Collections;
using System;

public class GameModel: IGameModel
{
    public GameModel()
    {
        Reset();
    }

    #region Live
    public int CurrentLive { get; set; }
    public int MaxLive { get; set; }

    public void DecreaseLive()
    {
        if (!IsDead())
        {
            CurrentLive--;
        }
    }

    public void IncreaseLive()
    {
        if (CurrentLive != MaxLive)
        {
            CurrentLive++;
        }
    }

    public void InstantDeath()
    {
        if (!IsDead())
        {
            CurrentLive = 0;
        }
    }

    public bool IsDead()
    {
        return (CurrentLive == 0);
    }
    #endregion

    #region DragonBall
    public int DragonBall { get; set; }

    public void IncreaseDragonBall()
    {
        if (DragonBall < 7)
        {
            DragonBall++;
        }
    }

    public void DecreaseDragonBall()
    {
        if (DragonBall > 0)
        {
            DragonBall--;
        }
    }

    public bool IsDragonBallComplete()
    {
        return (DragonBall == 7);
    }
    #endregion

    public void Reset()
    {
        if (CurrentLive != MaxLive)
        {
            CurrentLive = MaxLive;
        }

        if (DragonBall != 0)
        {
            DragonBall = 0;
        }
    }

}
