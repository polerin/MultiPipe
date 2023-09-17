#nullable enable
using Godot;
using System;

public partial class Player : Node
{
	[Export(PropertyHint.Range, "1,4,")]
	private int PlayerNumber = 1;

	public IPlayerController? PlayerController { set; private get; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.PlayerController?.PrepareInputs(this.PlayerNumber);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public override void _PhysicsProcess(double delta) 
	{
		if (this.PlayerController == null) {
			return;
		}

		InputInstruction instruction = this.PlayerController.GetInput();

		// execute instruction here
	}
}
