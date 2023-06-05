using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewUpgradesPanel : MonoBehaviour
{
	[SerializeField] private NewUpgradesSelector selector;
	[SerializeField] private ItemPanel itemPanelPrefab;
	[SerializeField] private WeaponPanel weaponPanelPrefab;
	[SerializeField] private GameObject panelContainer;
	[SerializeField] private List<GameObject> relatedPanels;
	[SerializeField] private Animator risePanelAnimator;

	private List<ItemPanel> itemPanels = new();
	private List<WeaponPanel> weaponPanels = new();



	private void Awake()
	{
		selector.OnNewUpgradesAvailable += OnNewUpgrades;
	}

	private void OnDestroy()
	{
		selector.OnNewUpgradesAvailable -= OnNewUpgrades;
	}


	private void OnNewUpgrades(List<Item> items, List<Weapon> weapons)
	{
		Time.timeScale = 0;

		foreach (var relatedPanel in relatedPanels)
		{
			relatedPanel.SetActive(true);
		}
		if (risePanelAnimator != null)
		{
			risePanelAnimator.Play("BaseLayer.Rise", 0, 0f);
		}


		for (var i = 0; i < items.Count; i++)
		{
			var newPanel = Instantiate(itemPanelPrefab, panelContainer.transform);
			newPanel.SetContent(items[i]);
			newPanel.OnItemSelected += OnUpgradeSelected;
			itemPanels.Add(newPanel);
		}

		for (var i = 0; i < weapons.Count; i++)
		{
			var newPanel = Instantiate(weaponPanelPrefab, panelContainer.transform);
			newPanel.SetContent(weapons[i]);
			newPanel.OnSelected += OnUpgradeSelected;
			weaponPanels.Add(newPanel);
		}
	}
	private void OnUpgradeSelected()

	{
		for (var i = itemPanels.Count - 1; i >= 0; i--)
		{
			itemPanels[i].OnItemSelected -= OnUpgradeSelected;
			Destroy(itemPanels[i].gameObject);
			itemPanels.RemoveAt(i);
		}

		for (var i = weaponPanels.Count - 1; i >= 0; i--)
		{
			weaponPanels[i].OnSelected -= OnUpgradeSelected;
			Destroy(weaponPanels[i].gameObject);
			weaponPanels.RemoveAt(i);
		}

		foreach (var relatedPanel in relatedPanels)
		{
			relatedPanel.SetActive(false);
		}

		Time.timeScale = 1;
	}
}

