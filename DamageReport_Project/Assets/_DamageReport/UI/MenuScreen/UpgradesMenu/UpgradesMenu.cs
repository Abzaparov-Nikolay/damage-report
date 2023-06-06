using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpgradesMenu : MonoBehaviour
{
	[SerializeField] private GameObject UpgradesScrollContent;
	[SerializeField] private GameObject UpgradePrefab;
	public Reference<UpgradeList> Upgrades;

	private List<GameObject> UIUpgrades = new();

	private void OnEnable()
	{
		ShowAllUpgrades();
	}

	private void OnDisable()
	{
		ClearAllUpgrades();
	}


	private void ShowAllUpgrades()
	{
		foreach (var upgrade in Upgrades.Value)
		{
			var upgrd = Instantiate(UpgradePrefab, UpgradesScrollContent.transform);
			var panel = upgrd.GetComponent<UpgradeStatPanel>();
			panel.SetFromUpgrade(upgrade);
			UIUpgrades.Add(upgrd);
		}
	}

	private void ClearAllUpgrades()
	{
		for (var i = UIUpgrades.Count - 1; i >= 0; i--)
		{
			Destroy(UIUpgrades[i]);
		}
	}
}
