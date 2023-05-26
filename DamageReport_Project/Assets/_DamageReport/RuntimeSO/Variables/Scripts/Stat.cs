using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;

[CreateAssetMenu(menuName = MenuNames.Stats + "Stat")]

public class Stat : Variable<float>
{
    private List<StatBonus> bonuses = new List<StatBonus>();
    private float calculatedValue;
    private bool valueUpToDate = false;

    public override float Value => Get();

    public void AddBonus(StatBonus bonus)
    {
        bonuses.Add(bonus);
        Recalculate();
    }

    public void RemoveBonus(StatBonus bonus)
    {
        bonuses.Remove(bonus);
        Recalculate();
    }

    public override float Get()
    {
        if (!valueUpToDate)
            Recalculate();
        return calculatedValue;
    }

    private void Recalculate()
    {
        bonuses = bonuses.OrderBy(x => x.order).ToList();
        float result = value;
        foreach (var bonus in bonuses)
        {
            result = bonus.Affect(result);
        }
        calculatedValue = result;
        valueUpToDate = true;
    }

    public static implicit operator float(Stat v) => v.Get();
}
