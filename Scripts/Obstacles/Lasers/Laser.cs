using Godot;

public partial class Laser : Area2D
{
	[Export]
	private int _speed = 500;
	
	[Export]
	private bool _rotating;

	public int Speed
	{
		get => _speed;
		set => _speed = value;
	}

	public bool Rotating
	{
		get => _rotating;
		set => _rotating = value;
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Rotation = GD.RandRange(0, 360);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(Position.X - _speed * (float)delta, Position.Y);
		if (_rotating)
		{
			Rotation += 1 *(float)delta;
		}
	}
	
	/// <summary>
	/// Destroy the laser when the timer is timeout
	/// </summary>
	public void OnLaserTimerTimeout()
	{
		GD.Print("POUF DISPARU");
		QueueFree();
	}
}
