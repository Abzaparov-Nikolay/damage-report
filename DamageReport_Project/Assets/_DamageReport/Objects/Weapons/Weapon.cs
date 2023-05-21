using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Weapon + "Weapon")]
public class Weapon : ScriptableObject
{
    public List<WeaponSlotType> fittingSlots;
    public List<GameObject> prefabs;
}
