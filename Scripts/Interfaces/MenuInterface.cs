using Godot;
using System;

public partial class MenuInterface : Control
{
	[Export] 
	private Button _playButton;

	[Export] 
	private Button _exitButton;
	
	[Signal]
	public delegate void PlayButtonPressedEventHandler();
	
	[Signal]
	public delegate void ExitButtonPressedEventHandler();

	/// <summary>
	/// Emit a signal when the "Play" button is pressed
	/// </summary>
	public void OnPlayButtonPressed()
	{
		EmitSignal(SignalName.PlayButtonPressed);
	}
	
	/// <summary>
	/// Emit a signal when the "Exit" button is pressed
	/// </summary>
	public void OnExitButtonPressed()
	{
		EmitSignal(SignalName.ExitButtonPressed);
	}
}
