using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = MenuNames.Upgrades + nameof(Upgrade))]
public class Upgrade : ScriptableObject
{
	public Stat stat;
	public string Name;
	public string Description;
	public float Cost;
	public StatBonus bonus;
	public string UID;

	private void OnValidate()
	{
		if (string.IsNullOrEmpty(UID))
		{
			AssignGUID();
		}
	}

	private void AssignGUID()
	{
		var path = AssetDatabase.GetAssetPath(this);
		UID = AssetDatabase.AssetPathToGUID(path);
		Debug.Log("CREATED GUID FOR UPGRADE");
#if UNITY_EDITOR
		UnityEditor.EditorUtility.SetDirty(this);
#endif
	}

	public void AddLevels(int amount)
	{
		bonus.level += amount;
	}

	public int GetLevel()
	{
		return bonus.level;
	}
}
