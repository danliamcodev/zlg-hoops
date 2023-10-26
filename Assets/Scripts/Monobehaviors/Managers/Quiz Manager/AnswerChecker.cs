using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerChecker : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _playerAnswerCorrect;
    [SerializeField] VoidEvent _playerAnswerWrong;

    [Header("References")]
    [SerializeField] IntVariable _correctAnswer;
    [SerializeField] IntVariable _playerAnswer;

    public void OnAnswerSubmitted()
    {
        CheckAnswer();
    }

    public void OnQuestionGenerated(QuizQuestion p_quizQuestion)
    {
        SetCorrectAnswer(p_quizQuestion);
    }

    private void CheckAnswer()
    {
        if (_correctAnswer.value == _playerAnswer.value)
        {
            _playerAnswerCorrect.Raise();
        } else
        {
            _playerAnswerWrong.Raise();
        }
    }

    private void SetCorrectAnswer(QuizQuestion p_quizQuestion)
    {
        _correctAnswer.SetValue(p_quizQuestion.answer);
    }
}
