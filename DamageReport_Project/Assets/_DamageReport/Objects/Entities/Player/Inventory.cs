using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Variable<Inventory> inventoryVariable;
    [SerializeField] private List<Item> items;
    [SerializeField] private List<WeaponSlot> weaponSlots;

    private void Awake()
    {
        inventoryVariable.Value = this;
    }

    private void Start()
    {
        if (items == null)
            items = new List<Item>();
        else
        {
            foreach (var item in items)
            {
                item.OnAddToInventory(gameObject);
            }
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        item.OnAddToInventory(gameObject);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
        item.OnRemoveFromInventory(gameObject);
    }

    public void AddWeapon(Weapon weapon)
    {
        foreach (var slot in weaponSlots)
        {
            if (weapon.fittingSlots.Contains(slot.type) && slot.weapon == null) {
                slot.weapon = weapon;
                for (var i = 0; i < weapon.prefabs.Count; i++)
                {
                    Instantiate(weapon.prefabs[i], slot.attachPoints[i].transform);
                }
                break;
            }
        }
    }

    public bool CanAddWeapon(Weapon weapon)
    {
        foreach (var slot in weaponSlots)
        {
            if (weapon.fittingSlots.Contains(slot.type) && slot.weapon == null)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveWeapon(Weapon weapon)
    {
        foreach (var slot in weaponSlots)
        {
            if (slot.weapon == weapon)
            {
                slot.weapon = null;
                foreach (var attachPoint in slot.attachPoints)
                {
                    foreach (Transform child in attachPoint.transform)
                    {
                        Destroy(child.gameObject);
                    }
                }
                break;
            }
        }
    }
}
