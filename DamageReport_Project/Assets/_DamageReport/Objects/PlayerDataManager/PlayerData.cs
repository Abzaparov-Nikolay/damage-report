using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
	private static PlayerData _instance;
	[SerializeField] private UpgradeList upgradesList;

	private Dictionary<string, Upgrade> AllUpgrades = new();
	public int Money { get; private set; }

	private string gameSavePath;

	public Action<object, int> MoneyChanged;
	//public Action<object, string> UpgradesChanged;

	public static PlayerData Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.Log("No instances of PlayerData has been created");
			}
			return _instance;
		}
	}

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}

		foreach (var upgrade in upgradesList)
		{
			AllUpgrades.Add(upgrade.UID, upgrade);
		}
		gameSavePath = Application.persistentDataPath + "/game_save.json";
	}

	private void Start()
	{
		LoadData();
		UpgradeStatPanel.UpgradeChanged += OnUpgradeSubmit;
	}



	private void LoadData()
	{
		if (!File.Exists(gameSavePath))
		{
			return;
		}
		PlayerDataSave save = JsonUtility.FromJson(File.ReadAllText(gameSavePath), typeof(PlayerDataSave)) as PlayerDataSave;
		if (save == null)
		{
			Money = 0;
			return;
		}
		Money = save.money;
		foreach (var upgrade in save.upgrades)
		{
			if (AllUpgrades.ContainsKey(upgrade.guid))
			{
				AllUpgrades[upgrade.guid].bonus.level = upgrade.level;
			}
			else
			{
				Debug.Log($"No such upgrade {upgrade.guid}");
			}
		}
	}

	public void SaveData()
	{
		var save = GeneratePlayerSave();
		var jsonSave = JsonUtility.ToJson(save);

		if (File.Exists(gameSavePath))
		{
			File.Delete(gameSavePath);
		}
		File.WriteAllText(gameSavePath, jsonSave);
	}

	private PlayerDataSave GeneratePlayerSave()
	{
		var save = new PlayerDataSave();
		save.money = Money;
		foreach ((var guid, var upgrade) in AllUpgrades)
		{
			save.AddUpgrade(upgrade);
		}
		return save;
	}

	public void GetMoney(int amount)
	{
		Money += amount;
		NotifyChanges();
		SaveData();
	}

	public void OnUpgradeSubmit(object sender, UpgradeChangeData data)
	{
		if (!AllUpgrades.ContainsKey(data.UID))
		{
			Debug.Log("No such Upgrade to upgrade");
			return;
		}
		if (!CanUpgrade(data.MoneySpent))
		{
			Debug.Log("Not enough money");
			return;
		}
		AllUpgrades[data.UID].AddLevels(data.LevelsToAdd);
		Money -= data.MoneySpent;
		NotifyChanges();
		SaveData();
	}

	private void NotifyChanges()
	{
		MoneyChanged?.Invoke(this, Money);
	}

	public bool CanUpgrade(int moneyToSpent)
	{
		return moneyToSpent <= Money;
	}
}

[Serializable]
public class UpgradeChangeData
{
	public string UID;
	public int LevelsToAdd;
	public int MoneySpent;

	public UpgradeChangeData(string uID, int levelsToAdd, int moneySpent)
	{
		UID = uID;
		this.LevelsToAdd = levelsToAdd;
		this.MoneySpent = moneySpent;
	}
}
