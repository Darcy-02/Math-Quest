public class Addition: Question
{
    public Addition(int first, int second, int level)
        : base(first, second, level)
    {
        correctAnswer = first + second;
    }

    public override string GetQuestionText()
    {
        return firstNumber + " + " + secondNumber + " = ?";
    }

    public override bool CheckAnswer(int playerAnswer)
    {
        return playerAnswer == correctAnswer;
    }
}
