public interface IGameModel
{
    void Reset();
    
    #region Live
    int CurrentLive{ get; set; }
    int MaxLive { get; set; }

    void DecreaseLive();
    void IncreaseLive();
    bool IsDead();
    void InstantDeath();
    #endregion

    #region Progress
    int DragonBall { get; set; }

    void IncreaseDragonBall();
    void DecreaseDragonBall();
    bool IsDragonBallComplete();
    #endregion
}
