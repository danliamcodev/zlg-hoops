using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TimerMode _timerMode;
    [SerializeField] BoolVariable _gameIsPaused;

    [Header("Variable")]
    [SerializeField] float _startingTime;
    [SerializeField] FloatVariable _time;
    bool _isActive = false;

    public float startingTime { get { return _startingTime; } }

    private void Start()
    {
        ResetTimer();
    }

    private void Update()
    {
        if (_gameIsPaused.value || !_isActive) return;
        CalcualteTime();
    }

    private void CalcualteTime()
    {
        _time.SetValue(_timerMode.CalculateTimeOnUpdate(_time.value));
    }

    public void ToggleTimerActive(bool p_timerIsActive)
    {
        _isActive = p_timerIsActive;
    }

    public void ResetTimer()
    {
        _time.SetValue(_startingTime);
    }
}
