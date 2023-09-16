using Godot;
using System;

public partial class MenuControl : Control
{
	private Button? StartGameButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		//hackety hack hack 
		this.StartGameButton = this.GetNode<Button>("MenuContainer/StartGameButton");
		this.StartGameButton.Pressed += this.loadGameScene;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void loadGameScene() {
		this.GetTree().ChangeSceneToFile("res://scenes/game_scene.tscn");
	}
}
