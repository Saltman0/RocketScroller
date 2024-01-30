using Godot;
using Godot.Collections;

public partial class AllScore : Resource
{
    [Export]
    private Array<int> _scores = new Array<int>();

    /// <summary>
    /// Add a new highscore
    /// </summary>
    /// <param name="highscore"></param>
    public void AddHighScore(int highscore)
    {
        _scores.Add(highscore);
        _scores.Sort();
        _scores.Reverse();
    }

    public int GetBestHighScore()
    {
        return _scores.Max();
    }
}
