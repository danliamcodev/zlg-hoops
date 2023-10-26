using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswersManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] List<Image> _buttonImages;
    [SerializeField] List<TextMeshProUGUI> _answerTexts;
    [SerializeField] Shuffler _shuffler;
    [SerializeField] IntVariable _playerAnswer;
    [SerializeField] IntVariable _correctAnswer;

    private Dictionary<TextMeshProUGUI, int> _choicePool;
    private int answer;

    public void OnQuizQuestionGenerated(QuizQuestion p_quizQuestion)
    {
        answer = p_quizQuestion.answer;
        List<int> choices = GenerateChoices(p_quizQuestion);
        UpdateAnswerText(choices);
        UpdateDictionary(choices);
        foreach (Image image in _buttonImages)
        {
            image.color = Color.white;
        }
    }

    public void OnAnswerSubmitted(TextMeshProUGUI p_answerText)
    {
        _playerAnswer.SetValue(_choicePool[p_answerText]);

        for (int i = 0; i < _answerTexts.Count; i++)
        {
            if (_answerTexts[i] == p_answerText)
            {
                if (_choicePool[p_answerText] != _correctAnswer.value)
                {
                    _buttonImages[i].color = Color.red;
                }
            }

            if (_choicePool[_answerTexts[i]] == _correctAnswer.value)
            {
                _buttonImages[i].color = Color.green;
            }
        }
    }

    private List<int> GenerateChoices(QuizQuestion p_quizQuestion)
    {
        List<int> choices = new List<int>();
        //Create correct choice
        choices.Add(answer);
        //Create Smaller Choice
        int smallerChoice = 0;
        do
        {
            int smallerChoiceModifier = (Random.Range(1, 3) * (Random.Range(0, 2) * 2 - 1));
            smallerChoice = (p_quizQuestion.number1 + smallerChoiceModifier) * p_quizQuestion.number2;
            if (smallerChoice < 0) smallerChoice = 0;
        } while (smallerChoice == 0 || choices.Contains(smallerChoice));
        choices.Add(smallerChoice);
        //Create Bigger Choice
        int biggerChoice = 0;
        do
        {
            int biggerChoiceModifier = (Random.Range(1, 3) * (Random.Range(0, 2) * 2 - 1));
            biggerChoice = p_quizQuestion.number1 * (p_quizQuestion.number2 + biggerChoiceModifier);
            if (biggerChoice < 0) biggerChoice = 0;
        } while (biggerChoice == 0 || choices.Contains(biggerChoice));
        choices.Add(biggerChoice);
        _shuffler.ShuffleList<int>(choices);
        return choices;
    }

    private void UpdateAnswerText(List<int> p_choices)
    {
        for (int i = 0; i < _answerTexts.Count; i++)
        {
            _answerTexts[i].text = p_choices[i].ToString();
        }
    }

    private void UpdateDictionary(List<int> p_choices)
    {
        _choicePool = new Dictionary<TextMeshProUGUI, int>();
        for (int i = 0; i < _answerTexts.Count; i++)
        {
            _choicePool.Add(_answerTexts[i], p_choices[i]);
        }
    }
}
