#nullable enable
using Godot;
using System;

/// <summary>
/// Listener for keyboard/controller on a specific machine.
/// 
/// This is not intended to directly controll a player, instead
/// it connects to the server and asks to move/place a piece.
/// All movement is done server side, then replicated locally by
/// RPC (for remote clients) or just shown (local clients)
/// </summary>
public class LocalPlayerController: IPlayerController
{
    private int ControllerIndex = -1;

    private PlayerInputMap PlayerInputMap;
    
    public void PrepareInputs(int controllerIndex)
    {
        this.ControllerIndex = controllerIndex;
        this.PlayerInputMap = new PlayerInputMap(controllerIndex);

    }

    public InputInstruction GetInput() 
    {
        if (this.ControllerIndex == -1) {
            return InputInstruction.None;
        }

        //Hackety HAAAACK
        if (Input.IsActionPressed(this.PlayerInputMap.Left)) {
            return InputInstruction.Left;
        }

        if (Input.IsActionPressed(this.PlayerInputMap.Right)) {
            return InputInstruction.Right;
        }

        if (Input.IsActionPressed(this.PlayerInputMap.Up)) {
            return InputInstruction.Up;
        }

        if (Input.IsActionPressed(this.PlayerInputMap.Down)) {
            return InputInstruction.Down;
        }

        if (Input.IsActionPressed(this.PlayerInputMap.Select0)) {
            return InputInstruction.Select0;
        }

        if (Input.IsActionPressed(this.PlayerInputMap.Select1)) {
            return InputInstruction.Select1;
        }

        if (Input.IsActionPressed(this.PlayerInputMap.Select2)) {
            return InputInstruction.Select2;
        }

        if (Input.IsActionPressed(this.PlayerInputMap.Select3)) {
            return InputInstruction.Select3;
        }

        return InputInstruction.None;
    }
}
