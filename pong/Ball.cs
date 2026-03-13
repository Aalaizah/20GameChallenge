using Godot;

public partial class Ball : Node2D
{
    private int _width;
    private int _xLoc;
    private int _yLoc;
    private int _speed;

    public override void _Ready()
    {
        var screenSize = GetViewportRect().Size;
        _width = (int)screenSize.Y;
        var random = new RandomNumberGenerator();
        _speed = random.RandiRange(1, 5);
    }

    public override void _Process(double delta)
    {
        
    }

    public void Bounce()
    {
        
    }
}
