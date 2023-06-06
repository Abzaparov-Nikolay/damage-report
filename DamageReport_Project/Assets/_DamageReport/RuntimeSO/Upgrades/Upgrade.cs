using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = MenuNames.Upgrades + nameof(Upgrade))]
public class Upgrade : ScriptableObject
{
	public Stat stat;
	public string Name;
	public string Description;
	public float Cost;
	public int Level;
	public StatBonus bonus;


}
