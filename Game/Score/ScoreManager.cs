namespace Snake.Score;

public class ScoreManager
{
    public int score { get; set; }

    public ScoreManager()
    {
        this.score = 0;
    }

    public void AddPoint()
    {
        if (score < 0) score = 0; else score += 1;
    }

    public void ResetScore()
    {
        score = 0;
    }
}