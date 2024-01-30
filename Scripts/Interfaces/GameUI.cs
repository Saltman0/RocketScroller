using Godot;

public partial class GameUI : Control
{
	[Signal]
	public delegate void ResumeButtonPressedEventHandler();
	
	[Signal]
	public delegate void PauseButtonPressedEventHandler();
	
	[Signal]
	public delegate void ReplayButtonPressedEventHandler();
	
	[Signal]
	public delegate void ReturnToMainMenuButtonPressedEventHandler();
	
	[Export]
	private Button _resumeButton;
	
	[Export]
	private Button _pauseButton;
	
	[Export]
	private Button _replayButton;
	
	[Export]
	private Button _returnToMainMenuButton;
	
	[Export]
	private VBoxContainer _gameOverAndButtonsContainer;

	[Export]
	private Label _gameLabel;

	[Export]
	private Label _gameStartLabel;

	[Export]
	private Label _scoreLabel;

	[Export] 
	private Label _bestScoreNumber;

	public override void _Ready()
	{
		UpdateBestScore();
	}

	public override void _Input(InputEvent @inputEvent)
	{
		if (@inputEvent.IsActionPressed("pause"))
		{
			if (GetTree().Paused)
			{
				_resumeButton.EmitSignal("pressed");
			}
			else
			{
				_pauseButton.EmitSignal("pressed");
			}
		}
	}
	
	/// <summary>
	/// Emit a signal when the "Pause" button is pressed
	/// </summary>
	public void OnPauseButtonPressed()
	{
		EmitSignal(SignalName.PauseButtonPressed);
		PauseGame();
	}

	/// <summary>
	/// Emit a signal when the "Resume" button is pressed
	/// </summary>
	public void OnResumeButtonPressed()
	{
		EmitSignal(SignalName.ResumeButtonPressed);
		ResumeGame();
	}

	/// <summary>
	/// Emit a signal when the "Resume" is pressed
	/// </summary>
	public void OnReplayButtonPressed()
	{
		EmitSignal(SignalName.ReplayButtonPressed);
	}

	/// <summary>
	/// Emit a signal when the "Return to main menu" button is pressed
	/// </summary>
	public void OnReturnToMainMenuButtonPressed()
	{
		EmitSignal(SignalName.ReturnToMainMenuButtonPressed);
	}

	public void UpdateBestScore()
	{
		_bestScoreNumber.Text = GetNode<ScoreManager>("/root/ScoreManager").LoadAllScore().GetBestHighScore().ToString();
	}
	
	/// <summary>
	/// Update the score
	/// </summary>
	/// <param name="score">The score</param>
	public void UpdateScore(int score)
	{
		_scoreLabel.Text = score.ToString();
	}

	/// <summary>
	/// Pause the game
	/// </summary>
	public void PauseGame()
	{
		_pauseButton.Visible = false;
		_resumeButton.Visible = true;
		_gameOverAndButtonsContainer.Visible = true;
		_gameLabel.Text = "Pause";
		_gameStartLabel.Visible = false;
		GetTree().Paused = true;
	}
	
	/// <summary>
	/// Resume the game
	/// </summary>
	public void ResumeGame()
	{
		GetTree().Paused = false;
		_pauseButton.Visible = true;
		_resumeButton.Visible = false;
		_gameOverAndButtonsContainer.Visible = false;
		_gameLabel.Text = "Pause";
		_gameStartLabel.Visible = false;
	}

	/// <summary>
	/// Display the "Game over"
	/// </summary>
	public void GameOver()
	{
		_pauseButton.Visible = false;
		_resumeButton.Visible = false;
		_gameOverAndButtonsContainer.Visible = true;
		_gameLabel.Text = "Game over";
		_gameStartLabel.Visible = false;
	}

	/// <summary>
	/// Hide the GameStart label
	/// </summary>
	public void HideGameStartLabel()
	{
		_gameStartLabel.Visible = false;
	}
}
