using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEngine.Localization;

[CreateAssetMenu(menuName = MenuNames.Upgrades + nameof(Upgrade))]
public class Upgrade : ScriptableObject
{
	public Stat stat;
	public LocalizedString Name;
	public string Description;
	public int Cost = 1;
	public StatBonus bonus;
	[HideInInspector] public string UID;

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
		Debug.Log("CREATED UID FOR UPGRADE");
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

	public void SetLevel(int newLevel)
	{
		bonus.level = newLevel;
	}
}
