using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatBonus : ScriptableObject
{
    public int order;
    public abstract float Affect(float value);
}
