using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatBonus : ScriptableObject
{
    [NonSerialized] public int level;
    public abstract float GetValue();
}
