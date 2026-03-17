using Godot;

public partial class Paddle : Node2D
{
    // private location
    // public set start location
    // public move y-axis
    // Member variables here, example:
    private int _yLoc = 50;
    private int _speed = 10;
    private int _p1XLoc;
    private int _p2XLoc = 500;
    private int _player = 1;
    private int _maxHeight;
    private int _minHeight;
    private int _paddleHeight = 100;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here.
        var screenSize = GetViewportRect().End;
        _minHeight = (int)screenSize.Y - _paddleHeight;
    }

    public override void _Process(double delta)
    {
        var upwardMovement = _yLoc - _speed;
        var downwardMovement = _yLoc + _speed;
        switch (_player)
        {
            case 1:
            {
                if (Input.IsActionPressed("p1UpPressed") && upwardMovement > _maxHeight)
                {
                    _yLoc -= _speed;
                    SetPosition(new Vector2(_p1XLoc, _yLoc));
                }

                if (Input.IsActionPressed("p1DownPressed") && downwardMovement < _minHeight)
                {
                    _yLoc += _speed;
                    SetPosition(new Vector2(_p1XLoc, _yLoc));
                }

                break;
            }
            case 2:
            {
                if (Input.IsActionPressed("p2UpPressed") && upwardMovement > _maxHeight)
                {
                    _yLoc -= _speed;
                    SetPosition(new Vector2(_p2XLoc, _yLoc));
                }

                if (Input.IsActionPressed("p2DownPressed") && downwardMovement < _minHeight)
                {
                    _yLoc += _speed;
                    SetPosition(new Vector2(_p2XLoc, _yLoc));
                }

                break;
            }
        }
        //SetPosition(new Vector2(50, _yLoc));
    }

    public void SetP1XLoc(int p1XLoc)
    {
        _p1XLoc = p1XLoc;
    }

    public void SetP2XLoc(int p2XLoc)
    {
        _p2XLoc = p2XLoc;
    }
    
    public void SetPlayer(int player)
    {
        _player = player;
    }
}
