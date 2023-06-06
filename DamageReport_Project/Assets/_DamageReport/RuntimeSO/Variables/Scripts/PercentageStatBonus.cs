using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Stats + "Percentage bonus")]
public class PercentageStatBonus : StatBonus
{
    public Reference<float> percentage;

    public override float Affect(float value)
    {
        return value * (percentage * level / 100f + 1f);
    }
}
