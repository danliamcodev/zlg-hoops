using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerator : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] QuizQuestionEvent _quizQuestionGenerated;
    List<int> _answerPool = new List<int>();
    // Start is called before the first frame update

    public void OnGenerateNewQuizQuestion()
    {
        QuizQuestion quizQuestion = GenerateQuizQuestion();
        _quizQuestionGenerated.Raise(quizQuestion);
    }

    private QuizQuestion GenerateQuizQuestion()
    {
        int number1 = 0;
        int number2 = 0;
        int answer = 0;
        do
        {
            number1 = Random.Range(1, 10);
            number2 = Random.Range(1, 10);
            answer = number1 * number2;
        } while (_answerPool.Contains(answer));

        _answerPool.Add(answer);

        return new QuizQuestion(number1, number2, answer);
    }
}

[System.Serializable]
public class QuizQuestion
{
    [SerializeField] int _number1;
    [SerializeField] int _number2;
    [SerializeField] int _answer;

    public int number1 { get { return _number1; } }
    public int number2 { get { return _number2; } }
    public int answer { get { return _answer; } }

    public QuizQuestion (int p_number1, int p_number2, int p_answer)
    {
        _number1 = p_number1;
        _number2 = p_number2;
        _answer = p_answer;
    }
}
