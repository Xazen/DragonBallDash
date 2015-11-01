using UnityEngine;
using System.Collections;

public interface IEnemyModel
{
    void Reset();

    #region Live
    int CurrentLive { get; set; }
    int MaxLive { get; set; }

    void DecreaseLive();
    void IncreaseLive();
    bool IsDead();
    void InstantDeath();
    #endregion
}
