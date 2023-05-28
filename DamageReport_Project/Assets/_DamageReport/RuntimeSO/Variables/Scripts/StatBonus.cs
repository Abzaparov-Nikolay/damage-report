using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatBonus : ScriptableObject, IComparable<StatBonus>
{
    public int order;
    public abstract float Affect(float value);

    public int CompareTo(StatBonus other) => order.CompareTo(other.order);
}
