using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UpgradesMenu : MonoBehaviour
{
	[SerializeField] private GameObject UpgradesScrollContent;
	[SerializeField] private GameObject UpgradePrefab;
	[SerializeField] private TextMeshProUGUI MoneyLeft;
	public Reference<UpgradeList> Upgrades;
	public Variable<PlayerData> PlayerData;

	private List<GameObject> UIUpgrades = new();

	private void OnEnable()
	{
		ShowAllUpgrades();
		if (PlayerData == null)
			return;
		ShowMoney(this, PlayerData.Value.Money);
		PlayerData.Value.MoneyChanged += ShowMoney;
	}

	private void OnDisable()
	{
		ClearAllUpgrades();
		PlayerData.Value.MoneyChanged += ShowMoney;
	}


	private void ShowMoney(object sender, int money)
	{
		MoneyLeft.text = money.ToString();
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
