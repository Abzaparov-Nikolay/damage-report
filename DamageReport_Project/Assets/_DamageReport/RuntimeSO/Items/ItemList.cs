using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Item + nameof(ItemList))]
public class ItemList : ScriptableObject, IEnumerable<Item>
{
    public List<Item> List;

    public IEnumerator<Item> GetEnumerator() => List.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
