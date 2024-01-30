using Godot;
using System;

public partial class DayBackground : ParallaxBackground
{
	[Export]
	private bool _scrollEnabled;

	[Export]
	private int _backgroundSpeed = 50;
	
	[Export]
	private ParallaxLayer _parallaxLayer;

	public bool ScrollEnabled
	{
		get => _scrollEnabled;
		set => _scrollEnabled = value;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (_scrollEnabled)
		{
			_parallaxLayer.MotionOffset -= new Vector2(_backgroundSpeed * (float)delta, _parallaxLayer.MotionOffset.Y);
		}
	}
}
