using System;
using Godot;
using Godot.Collections;
using RocketScroller.Scripts.Factories;

public partial class LaserSpawn : Node2D
{
	[Export] 
	private Array<PackedScene> _packedScenes;
	
	[Signal]
	public delegate void LaserSpawnedEventHandler(float positionX, float positionY);

	/// <summary>
	/// Create a wall and emit a "WallSpawned" signal when the timer is timeout
	/// </summary>
	public void OnLaserSpawnTimerTimeout()
	{
		Random random = new Random();
		
		EmitSignal(
			SignalName.LaserSpawned, 
			LaserFactory.CreateLaser(
				_packedScenes.PickRandom(),
				random.NextDouble() >= 0.5,
				GlobalPosition.X, 
				(float)GD.RandRange(
					GetNode<Marker2D>("LaserSpawnMarkerTop").GlobalPosition.Y, 
					GetNode<Marker2D>("LaserSpawnMarkerDown").GlobalPosition.Y
				)
			)
		);
	}
}
