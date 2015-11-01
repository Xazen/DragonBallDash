using UnityEngine;
using System.Collections;

public class EnemyModel : IEnemyModel
{
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

    public void Reset()
    {
        if (CurrentLive != MaxLive)
        {
            CurrentLive = MaxLive;
        }
    }
}
