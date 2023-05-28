using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Weapon + "Weapon")]
public class Weapon : ScriptableObject
{
    public List<WeaponSlotType> fittingSlots;
    public List<GameObject> prefabs;

    public Sprite Image;
    public string Title;
    [TextArea] public string Info;
    [TextArea] public string AdditionalDescription;
}
