using UnityEngine;
using TMPro;

public class TimePlayedTextUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] FloatVariable _time;
    [SerializeField] TextMeshProUGUI _scoreText;

    private void OnEnable()
    {
        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        float totalSeconds = _time.value;
        int minutes = Mathf.FloorToInt(totalSeconds / 60);
        int seconds = Mathf.FloorToInt(totalSeconds % 60);

        _scoreText.text = string.Format("{0:0} mins {1:00} secs", minutes, seconds);
    }
}
