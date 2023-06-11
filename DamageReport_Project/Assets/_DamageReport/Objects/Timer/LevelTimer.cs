using System;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private Variable<TimeSpan> currentLevelTime;

    private double currentTime;
    private bool isStopped = false;

    private void Update()
    {
        if (isStopped)
        {
            return;
        }
        currentTime += Time.deltaTime;
        currentLevelTime.Value = TimeSpan.FromSeconds(currentTime);
    }

	public void Stop()
	{
		isStopped = true;
	}
}
