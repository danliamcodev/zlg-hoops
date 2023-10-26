using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimerMode : ScriptableObject
{
    public abstract float CalculateTimeOnUpdate(float p_time);
}
