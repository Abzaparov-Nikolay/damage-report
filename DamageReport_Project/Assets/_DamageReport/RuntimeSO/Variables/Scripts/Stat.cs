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

    public override float Get()
    {
        if (!valueUpToDate)
            Recalculate();
        return calculatedValue;
    }

    private void Recalculate()
    {
        float result = initialValue;
        for (var order = 0; order < 3; order++)
        {
            foreach (var bonus in bonuses)
            {
                if (bonus.order == order)
                    result = bonus.Affect(result);
            }
        }

        calculatedValue = result;
        //Set(calculatedValue);
        valueUpToDate = true;
    }

    private void OnEnable()
    {
        Set(initialValue);
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
