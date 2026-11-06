
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text questionText;
    public TMP_Text levelText;
    public TMP_Text scoreText;
    public TMP_Text feedbackText;

    public TMP_InputField answerInput;
    public Button enterButton;

    [Header("Win")]
    public GameObject winPanel;

    private QuestionPrompter questionPrompter;
    private Question currentQuestion;

    private int currentLevel = 1;

    private const int TOTAL_LEVELS = 5;
    private const int POINTS_PER_QUESTION = 10;

    public UIManager uiManager;
    private ScoreManager scoreManager;

    private IGameState currentState;

    private void Start()
    {
        questionPrompter = new QuestionPrompter();

        questionPrompter.GenerateQuestions();

        currentLevel = 1;

        winPanel.SetActive(false);

        enterButton.onClick.AddListener(HandleSubmit);

        scoreManager = new ScoreManager();

        scoreManager.ResetScore();

        uiManager.Initialize(scoreManager);

        ChangeState(new Playing(this));


        LoadQuestion();
    }

    private void LoadQuestion()
    {
        currentQuestion = questionPrompter.GetQuestionForLevel(currentLevel);

        questionText.text = currentQuestion.GetQuestionText();

        levelText.text = "Level " + currentLevel + " / " + TOTAL_LEVELS;

        answerInput.text = "";
        feedbackText.text = "";

        answerInput.ActivateInputField();
    }

    public void CheckAnswer()
    {
        if (!int.TryParse(answerInput.text, out int playerAnswer))
        {
            feedbackText.text = "Please enter a valid number!";
            return;
        }

        if (currentQuestion.CheckAnswer(playerAnswer))
        {
            scoreManager.AddPoints(POINTS_PER_QUESTION);

            if (currentLevel < TOTAL_LEVELS)
            {
                currentLevel++;
                feedbackText.text = "Correct! Moving to the next level!";
                LoadQuestion();
            }
            else
            {
                ChangeState(new Win(this));
            }
        }
        else
        {
            feedbackText.text = "Not quite! Try again.";
            answerInput.text = "";
            answerInput.ActivateInputField();
        }
    }


    public void WinGame()
    {
        questionText.text = "";
        levelText.text = "All 5 levels completed!";
        feedbackText.text = "";

        winPanel.SetActive(true);
    }

    private void HandleSubmit()
    {
        currentState?.HandleSubmit();
    }

    private void ChangeState(IGameState newState)
    {
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }
}
