using System;
using System.Linq;
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
        availableItems = new Item[availableItemCount];
        for (var i = 0; i < availableItems.Length; i++)
        {
            if (items.List.Count >= availableItems.Length)
                availableItems[i] = items.List.Except(availableItems).ToArray().ChooseRandom();
            else
                availableItems[i] = items.List.ChooseRandom();
        }
        OnNewUpgradesAvailable?.Invoke(availableItems);
    }

    private void OnEnable()
    {
        availableItems = new Item[availableItemCount];
    }
}
