using Godot;
using System;

public partial class PlayerSelect : Control
{
	public bool PlayerIsActive { get; private set; }

	[Export(PropertyHint.Range, "1,4,")]
	private int PlayerNumber = 1;

	private PlayerDescription? PlayerDescription; 
	private Label PlayerNumberLabel;
	private Label PlayerSourceLabel;

	public void ActivatePlayer(PlayerDescription playerDescription) {
		if (playerDescription.PlayerNumber != this.PlayerNumber) {
			throw new InvalidDefinitionState($"Activated player number ({playerDescription.PlayerNumber}) does not match defined player number (${this.PlayerNumber})!");
		}

		this.PlayerDescription = playerDescription;
		this.DisplayActiveState();
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.PlayerNumberLabel = this.GetNode<Label>("PlayerNumber");
		this.PlayerSourceLabel = this.GetNode<Label>("PlayerSource");

		if (this.PlayerNumberLabel == null || this.PlayerSourceLabel == null) {
			throw new Exception($"Unable to correctly initialize player select for player number {this.PlayerNumber}");
		}

		this.PlayerNumberLabel.Text = $"Player {this.PlayerNumber}";
		this.DisplayActiveState();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void DisplayActiveState()
	{
		if (this.PlayerDescription == null) {
			this.PlayerSourceLabel.Text = "Waiting for player";

			return;
		}

		if (this.PlayerDescription?.PlayerSource == PlayerSource.Remote) {
			this.PlayerSourceLabel.Text = "Remote Player";

			return;
		}

		this.PlayerSourceLabel.Text = $"Controller {this.PlayerDescription?.ControllerNumber + 1}";
	}

}
