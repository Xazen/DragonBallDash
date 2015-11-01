public interface ILiveModel
{
    void Reset();

    void DecreaseLive();
    void IncreaseLive();
    bool IsDead();
    void InstantDeath();

    int CurrentLive{ get; set; }
    int MaxLive { get; set; }
}
