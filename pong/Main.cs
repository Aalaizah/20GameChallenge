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
    private PackedScene _ballScene = ResourceLoader.Load<PackedScene>("res://ball.tscn");
    private Paddle _player1Paddle;
    private Paddle _player2Paddle;
    private int[] _scores = [0, 0];
    private Timer _spawnBallTimer;
    private int _playerToSpawnTowards;

    public override void _Ready()
    { 
	    _spawnBallTimer = GetNode<Timer>("SpawnBallTimer");
	    //_spawnBallTimer.OneShot = true;
	    _spawnBallTimer.Timeout +=  _SpawnBall;
	    _playerToSpawnTowards = GD.RandRange(1, 2);
	    GD.Print(_playerToSpawnTowards);
	    _NewGame();
    }

    private void _PlayerScored(int player)
    {
	    switch (player)
	    {
		    case 1: 
			    _scores[0] += 1;
			    GetNode<Label>("Arena/P1 Score").Text = _scores[0].ToString();
			    _playerToSpawnTowards = 1;
			    break;
		    case 2: _scores[1] += 1;
			    GetNode<Label>("Arena/P2 Score").Text = _scores[1].ToString();
			    _playerToSpawnTowards = 2;
			    break;
	    }
	    _spawnBallTimer.OneShot = true;
	    _spawnBallTimer.Start();
    }

    private void _NewGame()
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
	    GetNode<Signals>("/root/Signals").PlayerScored += this._PlayerScored;
	    _SpawnBall();
	    
    }

    private void _SpawnBall()
    {
	    Ball ball = _ballScene.Instantiate<Ball>();
	    var viewportRect = GetViewportRect().Size;
	    var screenWidth = viewportRect.X;
	    var screenHeight = viewportRect.Y;
	    var ballSpawn = new Vector2(screenWidth / 2, screenHeight / 2);
	    int directionDegrees = 0;
	    //GD.Print(_playerToSpawnTowards);
	    switch (_playerToSpawnTowards)
	    {
		    case 1:
			    directionDegrees = GD.RandRange(135, 225);
			    break;
		    case 2:
			    int whereToAim = GD.RandRange(1, 2);
			    switch (whereToAim)
			    {
				    case 1:
					    directionDegrees = GD.RandRange(0, 45);
					    break;
				    case 2:
					    directionDegrees = GD.RandRange(315, 360);
					    break;
			    }
			    break;
	    }

	    float direction = Mathf.DegToRad(directionDegrees);//(float)GD.RandRange(-Mathf.Pi / 4, Mathf.Pi / 4);
	    var velocity = new Vector2((float)GD.RandRange(150.0, 250.0), 0);
	    ball.SpawnBall(ballSpawn, direction, velocity);
	    AddChild(ball);
    }

    private void _SpawnBall(int player)
    {
	    
    }

    private void _GameOver()
    {
	    
    }
}
