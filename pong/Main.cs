using Godot;

public partial class Main : Node2D
{
    // on load
    /*
     * spawn 2 paddles
     * spawn ball timer
     * res://paddle.tscn
     */
    private PackedScene _paddleScene = ResourceLoader.Load<PackedScene>("res://paddle.tscn");
    private Paddle _player1Paddle;
    private Paddle _player2Paddle;
    private int _player1Score;
    private int _player2Score;

    public override void _Ready()
    { 
	    _player1Paddle = _paddleScene.Instantiate<Paddle>();
	    _player1Paddle.Name = "player1";
	    _player1Paddle.SetP1XLoc(10);
	    _player1Paddle.Position = new Vector2(10, 50);
		AddChild(_player1Paddle);

		var screenWidth = GetViewportRect().End;
		var p2XLoc = screenWidth.X - 50;
		_player2Paddle = _paddleScene.Instantiate<Paddle>();
		_player2Paddle.Name = "player2";
		_player2Paddle.SetPlayer(2);
		_player2Paddle.SetP2XLoc((int)p2XLoc);
		_player2Paddle.Position = new Vector2(p2XLoc, 50);
		AddChild(_player2Paddle);
    }

    private void _NewGame()
    {
	    
    }

    private void _GameOver()
    {
	    
    }
}
