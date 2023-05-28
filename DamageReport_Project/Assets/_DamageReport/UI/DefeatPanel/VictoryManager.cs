using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private Variable<TimeSpan> levelTime;
    [SerializeField] private float endTimeInMinutes;
    [SerializeField] private UnityEvent onVictoryAchieved;

    private void Update()
    {
        if (levelTime.Value.TotalMinutes > endTimeInMinutes)
        {
            onVictoryAchieved?.Invoke();
        }
    }
}
