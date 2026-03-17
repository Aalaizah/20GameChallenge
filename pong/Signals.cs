using Godot;

public partial class Signals : Node
{
    [Signal]
    public delegate void PlayerScoredEventHandler(int player);
}
