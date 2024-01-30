using Godot;

public partial class Game : Node
{
	[Export]
	private Player _player;

	[Export] 
	private LaserSpawn _laserSpawn;
	
	[Export]
	private Node2D _obstacles;
	
	[Export]
	private GameUI _gameUi;
	
	[Export]
	private Timer _gameStartTimer;

	[Export]
	private DayBackground _dayBackground;
	
	[Export]
	private AudioStreamPlayer _gameOverAudio;
	
	private bool _isGameOver;
	
	private int _score;

	/// <summary>
	/// Get and set if the game is over
	/// </summary>
	public bool IsGameOver
	{
		get => _isGameOver;
		set => _isGameOver = value;
	}

	/// <summary>
	/// Get and set (and update) score
	/// </summary>
	public int Score
	{
		get => _score;
		set
		{
			_score = value;
			_gameUi.UpdateScore(_score);
		}
	}
	
	/// <summary>
	/// Game is over, save the score and update the best score when the player crashed
	/// </summary>
	public void OnPlayerCrashed()
	{
		IsGameOver = true;
		_gameStartTimer.Stop();
		_gameOverAudio.Play();
		_gameUi.GameOver();
		GetNode<ScoreManager>("/root/ScoreManager").SaveScore(_score);
		_gameUi.UpdateBestScore();
	}
	
	/// <summary>
	/// Add a wall when the wall spawner spawn something
	/// </summary>
	/// <param name="laser"></param>
	public void OnLaserSpawnLaserSpawned(Laser laser)
	{
		_obstacles.AddChild(laser);
	}

	/// <summary>
	/// Pause the game when the "Pause" button is pressed
	/// </summary>
	public void OnGameUIPauseButtonPressed()
	{
		_gameUi.PauseGame();
	}
	
	/// <summary>
	/// Replay the game when the "Replay" button is pressed
	/// </summary>
	public void OnGameUIReplayButtonPressed()
	{
		GetTree().Paused = false;
		GetTree().ChangeSceneToPacked(ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn"));
	}

	/// <summary>
	/// Resume the game when the "Resume" button is pressed
	/// </summary>
	public void OnGameUIResumeButtonPressed()
	{
		_gameUi.ResumeGame();
	}

	/// <summary>
	/// Return to the main menu when the "Return to menu" is pressed
	/// </summary>
	public void OnGameUIReturnToMainMenuButtonPressed()
	{
		GetTree().Paused = false;
		GetNode<SceneTransition>("/root/SceneTransition").ChangeScene(
			ResourceLoader.Load<PackedScene>("res://Scenes/Menu.tscn")
		);
	}
	
	/// <summary>
	/// Enable the wall spawner and hide the "Ready" label when the "Game start" timer is timeout
	/// </summary>
	public void OnGameStartTimerTimeout()
	{
		_player.ProcessMode = ProcessModeEnum.Inherit;
		_laserSpawn.ProcessMode = ProcessModeEnum.Inherit;
		_dayBackground.ScrollEnabled = true;
		_gameUi.HideGameStartLabel();
	}
}
