using Godot;

public partial class ScoreManager : Node
{
    private string _allScorePath = "user://AllScore.tres";
    
    /// <summary>
    /// Save a new highscore
    /// </summary>
    /// <param name="highscore"></param>
    public void SaveScore(int highscore)
    {
        // Check and create a new AllHighScore if it doesn't exit
        AllScore allScore = LoadAllScore();

        // Add the new highscore and sort the AllHighScore by the highest score
        allScore.AddHighScore(highscore);

        // Save the AllHighScore
        ResourceSaver.Save(allScore, _allScorePath);
    }

    /// <summary>
    /// Load the AllHighScore file
    /// </summary>
    /// <returns></returns>
    public AllScore LoadAllScore()
    {
        return ResourceLoader.Exists(_allScorePath) 
            ? (AllScore)SafeResourceLoader.Load(_allScorePath) 
            : new AllScore();
    }
}
