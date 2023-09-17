public struct PlayerInputMap
{
    public readonly string Left;
    public readonly string Right;
    public readonly string Up;
    public readonly string Down;
    public readonly string Select0;
    public readonly string Select1;
    public readonly string Select2;
    public readonly string Select3;

    public PlayerInputMap(int playerId) {
        this.Left = $"c{playerId}_move_left";
        this.Right = $"c{playerId}_move_right";
        this.Up = $"c{playerId}_move_up";
        this.Down = $"c{playerId}_move_down";
        this.Select0 = $"c{playerId}_select_0";
        this.Select1 = $"c{playerId}_select_1";
        this.Select2 = $"c{playerId}_select_2";
        this.Select3 = $"c{playerId}_select_3";
    }
}

public struct PlayerDescription
{
    public readonly PlayerSource PlayerSource;
    public readonly int PlayerNumber;
    public readonly int ControllerNumber;

    public PlayerDescription(PlayerSource playerSource, int playerNumber = -1, int controllerNumber = -1) {
        this.PlayerSource = playerSource;
        this.PlayerNumber = playerNumber;
        this.ControllerNumber = controllerNumber;
    }

    public static PlayerDescription CreateInactive() 
    {
        return new PlayerDescription(PlayerSource.Inactive);
    }

    public static PlayerDescription CreateLocal(int playerNumber, int controllerNumber)
    {
        return new PlayerDescription(PlayerSource.Local, playerNumber, controllerNumber);
    }

    public static PlayerDescription CreateRemote(int playerNumber)
    {
        return new PlayerDescription(PlayerSource.Remote, playerNumber);
    }
}

public enum PlayerSource { Local, Remote, Inactive }

public enum InputInstruction { None, Left, Right, Up, Down, Select0, Select1, Select2, Select3 }