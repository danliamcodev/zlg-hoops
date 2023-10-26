using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionTextUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _questionText; 
    public void UpdateQuestionText(QuizQuestion p_quizQuestion)
    {
        _questionText.text = string.Format("{0} x {1}", p_quizQuestion.number1, p_quizQuestion.number2);
    }
}
