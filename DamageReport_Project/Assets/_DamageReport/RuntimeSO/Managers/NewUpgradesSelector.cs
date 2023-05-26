using System;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Manager + nameof(NewUpgradesSelector))]
public class NewUpgradesSelector : ScriptableObject
{
    [SerializeField] private ItemList items;
    [SerializeField] private Reference<int> availableItemCount;

    private Item[] availableItems;

    public event Action<Item[]> OnNewUpgradesAvailable;

    public void OfferNewUpgrades()
    {
        for (var i = 0; i < availableItems.Length; i++)
        {
            availableItems[i] = items.List.ChooseRandom();
        }
        OnNewUpgradesAvailable?.Invoke(availableItems);
    }

    private void OnEnable()
    {
        availableItems = new Item[availableItemCount];
    }
}
