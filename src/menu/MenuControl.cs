using Godot;
using System;

public partial class MenuControl : Control
{
	private Button? ButtonStartGame;
    private Button? ButtonStartPolerin;
    private Button? ButtonStartGiTnEd;
    private Button? ButtonQuitToDesktop;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        //hackety hack hack 
        this.ButtonStartGame = this.GetNode<Button>("MenuContainer/HBoxContainer/LeftMenu/ButtonStartGame");
		this.ButtonStartGame.Pressed += () => this.LoadGameScene("game_scene");

        this.ButtonStartPolerin = this.GetNode<Button>("MenuContainer/HBoxContainer/LeftMenu/ButtonStartPolerin");
        this.ButtonStartPolerin.Pressed += () => this.LoadGameScene("test1_scene");

        this.ButtonStartGiTnEd = this.GetNode<Button>("MenuContainer/HBoxContainer/LeftMenu/ButtonStartGiTnEd");
        this.ButtonStartGiTnEd.Pressed += () => this.LoadGameScene("test2_scene");

        this.ButtonQuitToDesktop = this.GetNode<Button>("MenuContainer/HBoxContainer/LeftMenu/ButtonQuitToDesktop");
        this.ButtonQuitToDesktop.Pressed += () => this.ExitApplication();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void LoadGameScene(string scene_name) 
    {
		this.GetTree().ChangeSceneToFile("res://scenes/" + scene_name +".tscn");
	}

    private void ExitApplication()
    {
        GetTree().Root.PropagateNotification((int)NotificationWMCloseRequest);
        GetTree().Quit();
    }
}
