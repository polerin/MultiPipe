#nullable enable
using Godot;
using System;

public partial class PauseMenu : Node2D
{
    private Button? ButtonQuitToMenu;
    private Button? ButtonQuitToDesktop;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        //hackety hack hack 
        this.ButtonQuitToMenu = this.GetNode<Button>("MenuContainer/HBoxContainer/PauseMenu/ButtonQuitToMenu");
        this.ButtonQuitToMenu.Pressed += () => this.LoadGameScene("main_menu");

        this.ButtonQuitToDesktop = this.GetNode<Button>("MenuContainer/HBoxContainer/PauseMenu/ButtonQuitToDesktop");
        this.ButtonQuitToDesktop.Pressed += () => this.ExitApplication();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if (keyEvent.Keycode == Key.Escape)
            {
                this.Visible = !this.Visible;
            }
        }
    }

    private void LoadGameScene(string scene_name)
    {
        this.GetTree().ChangeSceneToFile("res://scenes/" + scene_name + ".tscn");
    }

    private void ExitApplication()
    {
        GetTree().Root.PropagateNotification((int)NotificationWMCloseRequest);
        GetTree().Quit();
    }
}
