using System;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private Variable<TimeSpan> currentLevelTime;

    private double currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime;
        currentLevelTime.Value = TimeSpan.FromSeconds(currentTime);
    }
}
