using Godot;

public partial class SceneTransition : CanvasLayer
{
    private PackedScene _newScene;

    [Export]
    private AnimationPlayer _animationPlayer;

    public void ChangeScene(PackedScene newScene)
    {
        _newScene = newScene;
        _animationPlayer.Play("FadeIn");
    }
    
    public void OnAnimationPlayerAnimationFinished(string animationName)
    {
        if (animationName == "FadeIn")
        {
            _animationPlayer.Play("FadeOut");
        }
        GetTree().ChangeSceneToPacked(_newScene);
    }
}