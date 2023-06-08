using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideUpgrader : MonoBehaviour
{
	[SerializeField] private UpgradeList upgradeList;

	private void Start()
	{
		foreach(var upgrade in upgradeList)
		{
			upgrade.stat.AddBonus(upgrade.bonus);
		}
	}
}
