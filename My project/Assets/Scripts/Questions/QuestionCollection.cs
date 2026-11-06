using System.Collections.Generic;

public class QuestionCollection
{
    private List<Question> questions = new List<Question>();

    public void AddQuestion(Question question)
    {
        questions.Add(question);
    }

    public Question FindQuestion(int level)
    {
        foreach (Question question in questions)
        {
            if (question.Level == level)
            {
                return question;
            }
        }

        return null;
    }
}