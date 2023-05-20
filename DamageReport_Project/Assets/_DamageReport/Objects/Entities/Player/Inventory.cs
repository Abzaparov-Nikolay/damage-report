using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> items;
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
}
