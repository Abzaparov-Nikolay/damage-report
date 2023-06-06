using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Stats + "Flat bonus")]

public class FlatStatBonus : StatBonus
{
    public Reference<float> amount;

    public override float Affect(float value)
    {
        return value + amount * level;
    }
}
