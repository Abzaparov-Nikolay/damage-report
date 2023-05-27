using System;
using TMPro;
using UnityEngine;

public class TimerTextSetter : MonoBehaviour
{
    [SerializeField] private Variable<TimeSpan> currentLevelTime;
    [SerializeField] private TextMeshProUGUI textField;

    private int currentTimeInSeconds;

    private void Update()
    {
        var newTimeInSeconds = (int)currentLevelTime.Value.TotalSeconds;
        if (newTimeInSeconds != currentTimeInSeconds)
        {
            currentTimeInSeconds = newTimeInSeconds;
            var format = currentLevelTime.Value switch
            {
                { Seconds: < 10, Minutes: < 10 } => "0{0}:0{1}",
                { Seconds: >= 10, Minutes: < 10 } => "0{0}:{1}",
                { Seconds: < 10, Minutes: >= 10 } => "{0}:0{1}",
                _ => "{0}:{1}",
            };
            textField.SetText(format, currentLevelTime.Value.Minutes, currentLevelTime.Value.Seconds);
        }
    }
}
