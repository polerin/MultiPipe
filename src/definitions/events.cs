/// <summary>
/// Delegate definition that signifies a request for the game state to change 
/// </summary>
/// <param name="newState"></param>
public delegate void GameStateChangeRequest(GameState newState);

/// <summary>
/// Delegate definition that signifies a notification that the game state has
/// moved from oldState and is now currently newState
/// </summary>
/// <param name="oldState"></param>
/// <param name="newState"></param>
public delegate void GameStateChangeNotification(GameState oldState, GameState newState);
