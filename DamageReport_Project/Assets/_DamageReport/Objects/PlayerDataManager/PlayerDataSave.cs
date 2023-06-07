using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerDataSave
{
	public int money;
	public List<UpgradeData> upgrades;

	public PlayerDataSave()
	{
		upgrades = new List<UpgradeData>();
	}

	public void AddUpgrade(Upgrade upgrade)
	{
		upgrades.Add(DataFromUpgrade(upgrade));
	}

	public void AddUpgrade(UpgradeData upgrade)
	{
		upgrades.Add(upgrade);
	}

	public UpgradeData DataFromUpgrade(Upgrade upgrade)
	{
		return new UpgradeData(upgrade);
	}
}
