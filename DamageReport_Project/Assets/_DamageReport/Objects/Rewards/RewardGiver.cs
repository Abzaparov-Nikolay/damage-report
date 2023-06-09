using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardGiver : MonoBehaviour
{
	[SerializeField] private Variable<PlayerData> playerData;
	[SerializeField] private Variable<TimeSpan> levelTimer;

	public void GiveReward()
	{
		if (playerData.Value == null)
			return;
		playerData.Value.GetReward(CountReward());
	}

	private Reward CountReward()
	{
		return new Reward((int)(Math.Pow(levelTimer.Value.TotalSeconds, 2) / Math.Log(levelTimer.Value.TotalSeconds, 2)));
	}
}

[Serializable]
public class Reward
{
	public int Money;

	public Reward(int money)
	{
		this.Money = money;
	}
}
