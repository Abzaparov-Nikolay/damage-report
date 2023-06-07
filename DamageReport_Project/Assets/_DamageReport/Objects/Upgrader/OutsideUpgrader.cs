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
			//upgrade.bonus.level = upgrade.Level;
			//if (upgrade.bonus.level == 0)
			//{
			//	upgrade.bonus.level = 1;
			//}
			upgrade.stat.AddBonus(upgrade.bonus);
		}
	}
}
