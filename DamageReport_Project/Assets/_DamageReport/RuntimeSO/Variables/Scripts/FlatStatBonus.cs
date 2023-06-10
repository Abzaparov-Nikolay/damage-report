using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Stats + "Flat bonus")]

public class FlatStatBonus : StatBonus
{
	public Reference<float> amount;
    public override float GetValue()
	{
		return amount * level;
	}

	public override string ToString()
	{
		return $"{amount * level}";
	}
}
