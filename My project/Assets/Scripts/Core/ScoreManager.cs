using System;

public class ScoreManager
{
    private int score;

    public event Action<int> ScoreChanged;

    public int CurrentScore => score;

    public void AddPoints(int points)
    {
        score += points;

        ScoreChanged?.Invoke(score);
    }

    public void ResetScore()
    {
        score = 0;

        ScoreChanged?.Invoke(score);
    }
}
