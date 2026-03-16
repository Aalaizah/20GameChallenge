using Godot;

public partial class Ball : RigidBody2D
{
	private int _width;
	private int _speed;

	public override void _Ready()
	{
		var screenSize = GetViewportRect().Size;
		_width = (int)screenSize.X;
		GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D").ScreenExited += Score;
	}

	public void SpawnBall(Vector2 position, float direction, Vector2 velocity)
	{
		Rotation = direction;
		Position = position;
		SetLinearVelocity(velocity.Rotated(direction));
	}

	public override void _Process(double delta)
	{
		var collision = MoveAndCollide(GetLinearVelocity() * (float)delta);
		if (collision != null)
		{
			SetLinearVelocity(GetLinearVelocity().Bounce(collision.GetNormal()));
		}
	}

	public void Score()
	{
		if (this.Position.X > _width)
		{
			GD.Print("p1 scored");
			GetNode<Signals>("/root/Signals").EmitSignal("PlayerScored", 1);
		}
		if (this.Position.X < 0)
		{
			GD.Print("p2 scored");
			GetNode<Signals>("/root/Signals").EmitSignal("PlayerScored", 2);
		}
		
		if (Input.IsActionPressed("p1ScoreTest"))
		{
			GetNode<Signals>("/root/Signals").EmitSignal("PlayerScored", 1);
		}
		if (Input.IsActionPressed("p2ScoreTest"))
		{
			GetNode<Signals>("/root/Signals").EmitSignal("PlayerScored", 2);
		}
	}
}
