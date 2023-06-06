using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = MenuNames.Upgrades + nameof(UpgradeList))]
public class UpgradeList : ScriptableObject, IEnumerable<Upgrade>
{
	public List<Upgrade> List;

	public IEnumerator<Upgrade> GetEnumerator()
	{
		return List.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
