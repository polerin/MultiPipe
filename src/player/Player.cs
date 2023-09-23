#nullable enable
using Godot;
using System;

public partial class Player : Node
{
	[Export(PropertyHint.Range, "1,4,")]
	private int PlayerNumber = 1;

	[Export(PropertyHint.Range, "0,10")]
	private Vector2I CurrentPosition = new Vector2I(0,0);

	public int BoardSize = 20;
	private double MovementDuration = 100;

	public bool Move(MovementDirection movement) 
	{
		switch(movement) {
			case MovementDirection.Up: 
				return this.MoveUp();
			case MovementDirection.Down:
				return this.MoveDown();
			case MovementDirection.Left:
				return this.MoveLeft();
			case MovementDirection.Right:
				return this.MoveRight();
		}

		return false;
	}

	public void SetPosition(Vector2I newPosition)
	{
		this.CurrentPosition = new Vector2I(
			Math.Clamp(newPosition.X, 0, this.BoardSize),
			Math.Clamp(newPosition.Y, 0 , this.BoardSize)
		);
		// Emit signal?
	}

	public bool MoveUp()
	{
		if (this.CurrentPosition.Y <= 0) {
			return false;
		}

		// @TODO check if this is actually the right direction? XD
		this.CurrentPosition = new Vector2I(
			this.CurrentPosition.X,
			this.CurrentPosition.Y - 1
		);

		// @TODO emit signal?
		return true;
	}

	public bool MoveDown()
	{
		// Does this need to be minus (or plus) 1? 
		if (this.CurrentPosition.Y >= this.BoardSize) {
			return false;
		}

		// @TODO check if this is actually the right direction? XD
		this.CurrentPosition = new Vector2I(
			this.CurrentPosition.X,
			this.CurrentPosition.Y + 1
		);

		// @TODO emit signal?

		return true;
	}

	public bool MoveLeft()
	{
		if (this.CurrentPosition.X >= 0) {
			return false;
		}

		// @TODO check if this is actually the right direction? XD
		this.CurrentPosition = new Vector2I(
			this.CurrentPosition.X - 1,
			this.CurrentPosition.Y
		);

		// @TODO emit signal?

		return true;
	}

	public bool MoveRight()
	{
		// Does this need to be minus (or plus) 1? 
		if (this.CurrentPosition.X >= this.BoardSize) {
			return false;
		}

		// @TODO check if this is actually the right direction? XD
		this.CurrentPosition = new Vector2I(
			this.CurrentPosition.X,
			this.CurrentPosition.Y + 1
		);

		// @TODO emit signal?

		return true;
	}
}
