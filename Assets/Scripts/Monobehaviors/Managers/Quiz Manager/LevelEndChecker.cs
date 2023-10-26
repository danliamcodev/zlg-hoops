using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndChecker : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] VoidEvent _generateQuizQuestion;
    [SerializeField] VoidEvent _endLevel;
    [SerializeField] VoidEvent _postGame;

    [Header("Variables")]
    [SerializeField] int _maxLevels = 10;
    [SerializeField] float _timeBeforeNextQuestion = 2f;

    int _currentLevel = 0;
    public void OnQuestionGenerated()
    {
        _currentLevel++;
    }

    public void OnAnswerSubmitted()
    {
        CheckLevelEnd();
    }

    private void CheckLevelEnd()
    {
        if (_currentLevel < _maxLevels)
        {
            Invoke(nameof(GenerateNextQuestion), _timeBeforeNextQuestion);
        } else
        {
            EndLevel();
        }
    }

    private void GenerateNextQuestion()
    {
        _generateQuizQuestion.Raise();
    }

    private void EndLevel()
    {
        _endLevel.Raise();

        Invoke(nameof(ShowPostGameScreen), _timeBeforeNextQuestion);
    }

    private void ShowPostGameScreen()
    {
        _postGame.Raise();
    }

    public void ResetLevels()
    {
        _currentLevel = 0;
    }
}
