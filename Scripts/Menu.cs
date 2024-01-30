using Godot;

public partial class Menu : Node
{
    [Export]
    private MenuInterface _menuInterface;

    private PackedScene _gameScene = ResourceLoader.Load<PackedScene>("res://Scenes/Game.tscn");
    
    /// <summary>
    /// Change the scene tree to the game scene when the "Play" button is pressed
    /// </summary>
    public void OnMenuInterfacePlayButtonPressed()
    {
        GetNode<SceneTransition>("/root/SceneTransition").ChangeScene(_gameScene);
    }
    
    /// <summary>
    /// Quit the game when the "Exit" button is pressed
    /// </summary>
    public void OnMenuInterfaceExitButtonPressed()
    {
        GetTree().Quit();
    }
}
