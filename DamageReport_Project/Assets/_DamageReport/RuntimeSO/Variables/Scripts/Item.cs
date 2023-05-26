using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Item + "Item")]
public class Item : ScriptableObject
{
    public List<StatAndBonus> StatBonuses;
    public List<GameObject> Behaviours;
    public Sprite Image;
    public string Title;
    [TextArea] public string Description;

    private List<GameObject> instantiatedBehaviours;

    public void OnAddToInventory(GameObject inventory)
    {
        foreach(var statBonus in StatBonuses)
        {
            var stat = statBonus.stat;
            var bonus = statBonus.statBonus;
            stat.AddBonus(bonus);
        }
        foreach (var behaviour in Behaviours)
        {
            instantiatedBehaviours.Add(Instantiate(behaviour, inventory.transform));
        }
    }

    public void OnRemoveFromInventory(GameObject inventory)
    {
        foreach (var statBonus in StatBonuses)
        {
            var stat = statBonus.stat;
            var bonus = statBonus.statBonus;
            stat.RemoveBonus(bonus);
        }
        foreach (var behaviour in instantiatedBehaviours)
        {
            Destroy(behaviour);
        }
        instantiatedBehaviours.Clear();
    }
}