using UnityEngine;

public abstract class Question
{
    protected int firstNumber;
    protected int secondNumber;
    protected int correctAnswer;

    public int Level { get; private set; }

    public Question(int first, int second, int level)
    {
        firstNumber = first;
        secondNumber = second;
        Level = level;
    }

    public abstract string GetQuestionText();

    public abstract bool CheckAnswer(int playerAnswer);
}

