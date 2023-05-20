using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Stats + "Multiplier bonus")]
public class MultiplierStatBonus : StatBonus
{
    public Reference<float> multiplier;

    public override float Affect(float value)
    {
        return value * multiplier;
    }
}
