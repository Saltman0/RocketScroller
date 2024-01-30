using Godot;
using System;

public partial class Ground : Area2D
{
	/// <summary>
	/// Crash the player when it enter in the ground
	/// </summary>
	/// <param name="player"></param>
	public void OnBodyEntered(Player player)
	{
		player.Crash();
	}
}
