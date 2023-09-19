using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerUI : Node2D
{
	public List<Vector2I> QueuePositions { get; set; }
    public List<Vector2I> SelectPositions { get; set; }

	public TileMap PlayerTileMap { get; set; }
	public int queueLayer = 0;
    public int selectLayer = 1;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        QueuePositions = new List<Vector2I> { new Vector2I(4,3), new Vector2I(5,3), new Vector2I(6,3), new Vector2I(7,3), new Vector2I(8,3) };
        SelectPositions = new List<Vector2I> { new Vector2I(5,6), new Vector2I(7,8), new Vector2I(5,10), new Vector2I(3,8) };
		PlayerTileMap = GetNode<TileMap>("PanelContainer/TileMap");

        foreach (var queuePosition in QueuePositions)
        {
            PlayerTileMap.SetCell(queueLayer, queuePosition, 0, GetRandomPipe());
        }
        foreach (var selectPosition in SelectPositions)
        {
            PlayerTileMap.SetCell(selectLayer, selectPosition, 0, GetRandomPipe());
        }
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void SelectPipe()
	{
		//Listen for event action (up,down,left,right)
		var selectIndex = 0; //CHANGE BASED ON INPUT
		//get tile at cell position of select position (SET ACTIVE PIPE to SELECTED)
		var selectedPipe = PlayerTileMap.GetCellAtlasCoords(selectLayer, SelectPositions[selectIndex]);
        //SET Player position/seletor to selectedpipe
	}

	public void ClearSelectedPipe()
	{
        //MOVE TO NEW METHODS - CLEAR PIPE ON EVENT PIPE PLACED
        //clear cell of selected after PIPE is placed
        //Listen for PIPE PLACED Event
        var selectIndex = 0; //CHANGE BASED ON EVENT
        GD.Print("Select Index = " + selectIndex);
        PlayerTileMap.EraseCell(selectLayer, SelectPositions[selectIndex]);
        UpdateQueue(selectIndex);
    }
    public void UpdateQueue(int selectIndex)
    {
        //MOVE TO new method - UpdateQueue 
        //Once cleared - get next PIPE from QUEUE (LAST ITEM)
        var nextPipe = PlayerTileMap.GetCellAtlasCoords(queueLayer, QueuePositions[QueuePositions.Count - 1]);
        //Add to cleared selected Pipe
        PlayerTileMap.SetCell(selectLayer, SelectPositions[selectIndex], 0, nextPipe);

        //push PIPES down queue
        for (int i = QueuePositions.Count - 1; i >= 0; i--)
        {
            if (i != 0) {
                //IF not index zero get previous pipe and place at index. Clear previous index cell
                var queuedPipe = PlayerTileMap.GetCellAtlasCoords(queueLayer, QueuePositions[i - 1]);
                PlayerTileMap.SetCell(queueLayer, QueuePositions[i], 0, queuedPipe);
                PlayerTileMap.EraseCell(queueLayer, QueuePositions[i - 1]);
            } else {
                //ADD new random PIPE sprite to front of QUEUE
                PlayerTileMap.SetCell(queueLayer, QueuePositions[i], 0, GetRandomPipe());
            }

        }
    }

    private Vector2I GetRandomPipe()
	{
		//Select a random PIPE from TileSet
		var rowMax = 3;
		var rowMin = 0;
		var colMax = 14;
		var colMin = 0;

        Random r = new Random();
        int randomRow = r.Next(rowMin, rowMax + 1);
        int randomCol = r.Next(colMin, colMax + 1);

		GD.Print("(" + randomCol + "," + randomRow + ")"); //@todo - remove debug line
		return new Vector2I(randomCol, randomRow);
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
        {
            if (keyEvent.Keycode == Key.Space)
            {
                ClearSelectedPipe();
            }
        }
    }
}
