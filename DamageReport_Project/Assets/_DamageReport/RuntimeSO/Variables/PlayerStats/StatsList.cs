using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =MenuNames.Stats+nameof(StatsList))]
public class StatsList : ScriptableObject, IEnumerable<Stat>
{
    public List<Stat> StatList;

	public IEnumerator<Stat> GetEnumerator()
	{
		return StatList.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}
