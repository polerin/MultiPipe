using Godot;
using System;

public partial class GameFlowContainer : Node
{
	[Export]
	protected string TargetGameScene = "game_scene";
	protected Node LoadedScene;
	protected GameStateContainer CurrentGameState;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.CurrentGameState = new GameStateContainer();
		this.ShowStartGameScene();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	protected void ShowStartGameScene()
	{
		if (LoadedScene != null) {
			GD.Print("Attempting to show start game when game is already underway");

			return;
		}

		this.SetCurrentChildScene("start_game");
	}

	protected void SetCurrentChildScene(string scenePath) 
	{
		this.FreeAllChildren();
		this.LoadedScene = ResourceLoader.Load<PackedScene>($"res://scenes/{scenePath}.tscn").Instantiate();

		if (this.LoadedScene is IGameStateAware) {
			(this.LoadedScene as IGameStateAware).AddGameState(this.CurrentGameState);
			(this.LoadedScene as IGameStateAware).RequestNewState += this.HandleGameStateChangeRequest;
		}

		this.AddChild(this.LoadedScene);

	}

	protected void FreeAllChildren() 
	{
		int childCount = this.GetChildCount();

		if (childCount == 0) {
			return;
		}

		//walking backwards so as to try and not run into index changes
		for (int i = childCount -1 ; i >= 0; i--) {
			Node child = this.GetChild(i);
			
			if (child is IGameStateAware) {
				(child as IGameStateAware).RequestNewState -= this.HandleGameStateChangeRequest;
			}

			this.GetChild(i).Free(); 
			
		}
	}

	protected void HandleGameStateChangeRequest(GameState newState) 
	{
		if (newState == GameState.BeforeStart) {
			this.SetCurrentChildScene(this.TargetGameScene);
		}
	}
}
