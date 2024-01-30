using Godot;

public partial class Player : CharacterBody2D
{
	[Export]
	private int _speed = 300;
	
	[Export]
	private int _flyVelocity = -300;

	[Export]
	private bool _crashed;
	
	[Signal]
	public delegate void CrashedEventHandler();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y += ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
		Velocity = velocity;
		HandleFly();
		MoveAndSlide();
	}
	
	/*public override void _Input(InputEvent @inputEvent)
	{
		if (@inputEvent.IsActionPressed("fly"))
		{
			Fly();
		}
	}*/
	
	/// <summary>
	/// Perform a jump
	/// </summary>
	public void HandleFly()
	{
		if (_crashed == false && Input.IsActionPressed("fly")) 
		{
			Velocity = new Vector2(0, _flyVelocity);
		}
	}

	/// <summary>
	/// Crash the player, perform a jump and emit a "Crashed" signal
	/// </summary>
	public void Crash()
	{
		if (_crashed == false)
		{
			_crashed = true;
			Velocity = new Vector2(0, Velocity.Y + _flyVelocity);
			EmitSignal(SignalName.Crashed);
		}
	}
}
