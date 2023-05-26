using System.Collections.Generic;
using UnityEngine;

public class NewUpgradesPanel : MonoBehaviour
{
    [SerializeField] private NewUpgradesSelector selector;
    [SerializeField] private ItemPanel itemPanelPrefab;
    [SerializeField] private GameObject panelContainer;
    [SerializeField] private List<GameObject> relatedPanels;

    private List<ItemPanel> itemPanels = new();

    private void Awake()
    {
        selector.OnNewUpgradesAvailable += OnNewUpgrades;
    }

    private void OnDestroy()
    {
        selector.OnNewUpgradesAvailable -= OnNewUpgrades;
    }

    private void OnNewUpgrades(Item[] items)
    {
        Time.timeScale = 0;

        foreach (var relatedPanel in relatedPanels)
        {
            relatedPanel.SetActive(true);
        }

        for (var i = 0; i < items.Length; i++)
        {
            var newItemPanel = Instantiate(itemPanelPrefab, panelContainer.transform);
            newItemPanel.SetContent(items[i]);
            newItemPanel.OnItemSelected += OnItemSelected;
            itemPanels.Add(newItemPanel);
        }
    }

    private void OnItemSelected()
    {
        for (var i = itemPanels.Count - 1; i >= 0; i--)
        {
            itemPanels[i].OnItemSelected -= OnItemSelected;
            Destroy(itemPanels[i].gameObject);
            itemPanels.RemoveAt(i);
        }

        foreach (var relatedPanel in relatedPanels)
        {
            relatedPanel.SetActive(false);
        }

        Time.timeScale = 1;
    }
}
