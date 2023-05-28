using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Weapon + nameof(WeaponPool))]
public class WeaponPool : ScriptableObject
{
    public List<Weapon> List;
}
