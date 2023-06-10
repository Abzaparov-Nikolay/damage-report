using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBonusesToStats : MonoBehaviour
{
    public List<StatAndBonus> StatBonuses;
    public void Apply()
    {
        foreach (var statBonus in StatBonuses)
        {
            var stat = statBonus.stat;
            var bonus = statBonus.statBonus;
            bonus.level = 1;
            stat.AddBonus(bonus);
        }
    }
    public void Remove()
    {
        foreach (var statBonus in StatBonuses)
        {
            var stat = statBonus.stat;
            var bonus = statBonus.statBonus;
            stat.RemoveBonus(bonus);
        }
    }
}
