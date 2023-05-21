using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class WeaponSlot
{
    public Weapon weapon;
    public WeaponSlotType type;
    public List<GameObject> attachPoints;
}
