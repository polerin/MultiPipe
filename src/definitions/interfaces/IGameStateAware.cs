public interface IGameStateAware
{
    GameStateChangeRequest RequestNewState { get; set; }
    void AddGameState(GameStateContainer gameState);
}