using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Countdown Timer Mode", menuName ="Utility/Timer Modes/Countdown")]
public class CountdownTimerMode : TimerMode
{
    [SerializeField] VoidEvent _countdownTimerUp;
    [SerializeField] IntVariable _playerAnswer;
    public override float CalculateTimeOnUpdate (float p_time)
    {
        float time = p_time;
        time -= Time.deltaTime;
        if (time < 0)
        {
            _playerAnswer.SetValue(0);
            _countdownTimerUp.Raise();
            return 0;
        } 
        return time;
    }
}
