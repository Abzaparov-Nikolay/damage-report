using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

[CreateAssetMenu(menuName = MenuNames.Stats + "Stat")]

public class Stat : Variable<float>
{
    private List<StatBonus> bonuses = new();
    private float calculatedValue;
    private bool valueUpToDate = false;

    public override float Value => Get();

    public void AddBonus(StatBonus bonus)
    {
        bonuses.Add(bonus);
        Recalculate();
        RaiseOnChanged();
    }

    public void RemoveBonus(StatBonus bonus)
    {
        bonuses.Remove(bonus);
        Recalculate();
		RaiseOnChanged();
    }


    public void BonusChanged()
    {
        Recalculate();
        RaiseOnChanged();
    }

    public override float Get()
    {
        if (!valueUpToDate)
            Recalculate();
        return calculatedValue;
    }

    private void Recalculate()
    {
        float result = initialValue;
        float totalFlatBonus = 0;
        float totalPercentageBonus = 0;
        foreach (var bonus in bonuses)
        {
            switch(bonus)
            {
                case FlatStatBonus fBonus:
                    totalFlatBonus += fBonus.GetValue();
                    break;
                case PercentageStatBonus pBonus:
                    totalPercentageBonus += pBonus.GetValue();
                    break;
            }
        }
        result += totalFlatBonus;
        result *= (totalPercentageBonus / 100f) + 1f;
        calculatedValue = result;
        //Set(calculatedValue);
        valueUpToDate = true;
    }

    private void OnEnable()
    {
        Set(initialValue);
        valueUpToDate = false;
        SceneManager.sceneUnloaded += OnSceneChanged;
    }

    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= OnSceneChanged;
    }

    private void OnSceneChanged(Scene scene)
    {
        Set(initialValue);
        bonuses = new();
        valueUpToDate = false;
    }

    public static implicit operator float(Stat v) => v.Get();
}
