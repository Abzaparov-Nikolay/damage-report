using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Manager + nameof(NewUpgradesSelector))]
public class NewUpgradesSelector : ScriptableObject
{
    [SerializeField] private ItemList items;
    [SerializeField] private WeaponPool weapons;
    [SerializeField] private Reference<int> availableUpgradeCount;
    [SerializeField, Range(0, 1)] private float weaponChance;
    [SerializeField] private Variable<Inventory> inventory;

    private List<Item> availableItems = new();
    private List<Weapon> availableWeapons = new();

    public event Action<List<Item>, List<Weapon>> OnNewUpgradesAvailable;

    public void OfferNewUpgrades()
    {
        availableItems.Clear();
        availableWeapons.Clear();

        for (var i = 0; i < availableUpgradeCount; i++)
        {
            if (UnityEngine.Random.value < weaponChance)
            {
                var weapon = weapons.List.ChooseRandom();
                if (!availableWeapons.Contains(weapon) && inventory.Value.CanAddWeapon(weapon))
                {
                    availableWeapons.Add(weapon);
                    continue;
                }
            }
            if (items.List.Count >= availableUpgradeCount - i)
                availableItems.Add(items.List.Except(availableItems).ToArray().ChooseRandom());
            else
                availableItems.Add(items.List.ChooseRandom());
        }
        OnNewUpgradesAvailable?.Invoke(availableItems, availableWeapons);
    }
}
