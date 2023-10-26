using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderCountdownTimerUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Timer _timer;
    [SerializeField] FloatVariable _time;
    [SerializeField] Slider _slider;

    private void Update()
    {
        _slider.value = _time.value / _timer.startingTime;
    }
}
