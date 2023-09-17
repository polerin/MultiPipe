using Godot;
using System;

public partial class GameSetupControl : Control
{

	private PlayerDescription[] PlayerDescriptions = {
		PlayerDescription.CreateInactive(),
		PlayerDescription.CreateInactive(),
		PlayerDescription.CreateInactive(),
		PlayerDescription.CreateInactive()
	};

	private PlayerSelect[] PlayerSlots = new PlayerSelect[4];

	private bool[] ControllerActivation = {false, false, false, false};

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		for (int i = 0; i < 4; i++) {
			this.FindSlot(i);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		for (int i = 0; i < 4; i++) {
			this.CheckController(i);
		}
	}

	private void FindSlot(int slotIndex)
	{
		this.PlayerSlots[slotIndex] = this.GetNode<PlayerSelect>("%PlayerSelect" + (slotIndex + 1));

		if (this.PlayerSlots[slotIndex] == null) {
			throw new Exception($"Unable to find player slot index {slotIndex}");
		}
	}

	private void CheckController(int controllerId)
	{
		// Xbox "B"
		if (this.ControllerActivation[controllerId] == true  && Input.IsActionPressed($"c{controllerId}_select_1")) {
			// TODO Deactivate player assignment!
			return;
		}
        
		// Xbox "A"
		if (this.ControllerActivation[controllerId] == false && Input.IsActionPressed($"c{controllerId}_select_2")) {
			this.ActivateLocalPlayer(controllerId);
		}
	}

	private void ActivateLocalPlayer(int controllerId)
	{
		int playerSlot = this.FindFirstAvailableSlot();

		if (playerSlot == -1) {
			GD.Print("Player queue is full but player is attmpting to join");
			return;
		}

		this.PlayerDescriptions[playerSlot] = PlayerDescription.CreateLocal(playerSlot, controllerId);
		
	}

	/// <summary>
	/// Find the first available player slot, returns -1 if none available
	/// </summary>
	/// <returns></returns> <summary>
	/// 
	/// </summary>
	/// <returns></returns>
	private int FindFirstAvailableSlot()
	{
		for (int i = 0; i < 4; i++) {
			if (this.PlayerDescriptions[i].PlayerSource == PlayerSource.Inactive) {
				return i;
			}
		}

		return -1;
	}
}
