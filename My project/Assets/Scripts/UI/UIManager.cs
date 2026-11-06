using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text scoreText;

    private ScoreManager scoreManager;

    public void Initialize(ScoreManager manager)
    {
        scoreManager = manager;

        scoreManager.ScoreChanged += UpdateScore;

        UpdateScore(scoreManager.CurrentScore);
    }

    private void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }

    private void OnDestroy()
    {
        if (scoreManager != null)
        {
            scoreManager.ScoreChanged -= UpdateScore;
        }
    }
}