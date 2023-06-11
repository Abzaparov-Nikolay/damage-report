using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = MenuNames.Weapon + "Weapon")]
public class Weapon : ScriptableObject
{
	public List<WeaponSlotType> fittingSlots;
	public List<GameObject> prefabs;

	public Sprite Image;
	public LocalizedString Title;
	public LocalizedString Info;
	public LocalizedString AdditionalDescription;
}
