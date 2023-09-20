using Godot;
using System;

public partial class GameSetupControl : Control, IGameStateAware
{

	public GameStateChangeRequest RequestNewState { get; set; }

	private GameStateContainer CurrentGame;

	private PlayerSelect[] PlayerSelects = new PlayerSelect[4];

	private bool[] ControllerActivation = {false, false, false, false};

	private Button StartGameButton;
	private Button CancelGameButton;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		for (int i = 0; i < 4; i++) {
			this.FindSlotNode(i);
		}

		this.StartGameButton = this.GetNode<Button>("%StartGameButton");
		this.StartGameButton.Pressed += this.RequestStartGame;
		
		this.CancelGameButton = this.GetNode<Button>("%CancelGameButton");
		this.CancelGameButton.Pressed += () => this.LoadGameScene("main_menu");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		for (int i = 0; i < 4; i++) {
			this.CheckController(i);
		}
	}

	public void AddGameState(GameStateContainer gameState)
	{
		this.CurrentGame = gameState;
	}

	private void FindSlotNode(int slotIndex)
	{
		this.PlayerSelects[slotIndex] = this.GetNode<PlayerSelect>("%PlayerSelect" + (slotIndex + 1));

		if (this.PlayerSelects[slotIndex] == null) {
			throw new Exception($"Unable to find player slot index {slotIndex}");
		}
	}

	/// <summary>
	/// @Todo refactor this method in GameSetupControl and MenuControl
	/// </summary>
	/// <param name="scene_name"></param> <summary>
	/// 
	/// </summary>
	/// <param name="scene_name"></param>
	private void LoadGameScene(string scene_name) 
    {
		this.GetTree().ChangeSceneToFile("res://scenes/" + scene_name +".tscn");
	}

	private void RequestStartGame()
	{
		if (this.RequestNewState != null) {
			this.RequestNewState(GameState.BeforeStart);
		}
	}

	private void CheckController(int controllerId)
	{
		// Xbox "B"
		if (this.ControllerActivation[controllerId] == true  && Input.IsActionJustPressed($"c{controllerId}_select_1")) {
			// TODO Deactivate player assignment!

			return;
		}
        
		// Xbox "A"
		if (this.ControllerActivation[controllerId] == false && Input.IsActionJustPressed($"c{controllerId}_select_2")) {
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

		this.CurrentGame.Players[playerSlot] = PlayerDescription.CreateLocal(playerSlot, controllerId);
		this.PlayerSelects[playerSlot].ActivatePlayer(this.CurrentGame.Players[playerSlot]);
		this.ControllerActivation[controllerId] = true;
		
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

			GD.Print($"Checking player slot {i}, status {this.CurrentGame.Players[i].PlayerSource}");
			if (this.CurrentGame.Players[i].PlayerSource == PlayerSource.Inactive) {
				return i;
			}
		}

		return -1;
	}
}
