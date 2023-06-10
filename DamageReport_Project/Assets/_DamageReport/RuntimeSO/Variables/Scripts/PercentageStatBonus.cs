using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Stats + "Percentage bonus")]
public class PercentageStatBonus : StatBonus
{
    public Reference<float> percentage;
    public override float GetValue()
    {
        return percentage * level;
    }

	public override string ToString()
	{
        return $"{percentage * level}";
	}
}
