using Godot;
using System;

public partial class GameSceneControl : Node2D, IGameStateAware
{

	public GameStateChangeRequest RequestNewState { get; set; }

	private GameStateContainer CurrentGame;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AddGameState(GameStateContainer gameState)
	{
		this.CurrentGame = gameState;
		GD.Print(gameState);	
		GD.Print($"Current game state has ${gameState?.Players.Length}");
	}
}
