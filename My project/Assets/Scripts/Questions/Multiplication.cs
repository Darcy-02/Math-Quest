public class Multiplication : Question
{
    public Multiplication(int first, int second, int level)
        : base(first, second, level)
    {
        correctAnswer = first * second;
    }

    public override string GetQuestionText()
    {
        return firstNumber + " x " + secondNumber + " = ?";
    }

    public override bool CheckAnswer(int playerAnswer)
    {
        return playerAnswer == correctAnswer;
    }
}
