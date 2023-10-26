using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stopwatch Timer Mode", menuName = "Utility/Timer Modes/Stopwatch")]
public class StopwatchTimerMode : TimerMode
{
    public override float CalculateTimeOnUpdate(float p_time)
    {
        float time = p_time;
        time += Time.deltaTime;
        return time;
    }
}