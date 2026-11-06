using UnityEngine;

public class QuestionPrompter
{
    private QuestionCollection questionCollection =
        new QuestionCollection();

    public Question CreateQuestion(int level)
    {
        switch (level)
        {
            case 1:
                return new Addition(
                    Random.Range(1, 6),
                    Random.Range(1, 6),
                    1
                );

            case 2:
                int first = Random.Range(5, 16);
                int second = Random.Range(1, first + 1);

                return new Subtraction(first, second, 2);

            case 3:
                return new Multiplication(
                    Random.Range(2, 11),
                    Random.Range(2, 11),
                    3
                );

            case 4:
                int divisor = Random.Range(2, 11);
                int quotient = Random.Range(2, 11);

                return new Division(
                    divisor * quotient,
                    divisor,
                    4
                );

            case 5:
                int operation = Random.Range(0, 4);

                switch (operation)
                {
                    case 0:
                        return new Addition(
                            Random.Range(20, 51),
                            Random.Range(20, 51),
                            5
                        );

                    case 1:
                        int bigger = Random.Range(30, 101);

                        return new Subtraction(
                            bigger,
                            Random.Range(10, bigger),
                            5
                        );

                    case 2:
                        return new Multiplication(
                            Random.Range(5, 13),
                            Random.Range(5, 13),
                            5
                        );

                    default:
                        int d = Random.Range(2, 13);
                        int q = Random.Range(5, 13);

                        return new Division(d * q, d, 5);
                }

            default:
                throw new System.ArgumentOutOfRangeException(
                    nameof(level),
                    "Level must be between 1 and 5."
                );
        }
    }

    public void GenerateQuestions()
    {
        for (int level = 1; level <= 5; level++)
        {
            Question question = CreateQuestion(level);
            questionCollection.AddQuestion(question);
        }
    }

    public Question GetQuestionForLevel(int level)
    {
        return questionCollection.FindQuestion(level);
    }
}