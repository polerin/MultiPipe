using Godot;
using System;

public partial class GameBoardMap : TileMap
{
	public int TileRow = 3;
	private int PipesLayer = 0;
	private int FillLayer = 0; // todo update also is this how we want to do it? :P

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.FillMap();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void FillMap() {
		for (int x = 0; x < 10; x++ ) {
			for (int y = 0; y < 10; y++) {
				this.SetCell(this.PipesLayer, new Vector2I(x,y), 0, new Vector2I(this.TileRow, 3));
			}
		}
	}
}
