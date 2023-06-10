using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
	[SerializeField] private Variable<PlayerData> so;
	[SerializeField] private UpgradeList upgradesList;

	private Dictionary<string, Upgrade> AllUpgrades = new();
	public int Money { get; private set; }

	private string gameSavePath;

	public Action<object, int> MoneyChanged;
	

	private void Awake()
	{
		if (so.Value == null)
		{
			so.Set(this);
			
		}
		else
		{
			Debug.Log("PlayerData exists");
		}

		foreach (var upgrade in upgradesList)
		{
			AllUpgrades.Add(upgrade.UID, upgrade);
		}
		gameSavePath = Application.persistentDataPath + "/game_save.json";

		SceneManager.sceneUnloaded += OnSceneChange;
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
			GiveStarterPack();
			return;
		}
		PlayerDataSave save = JsonUtility.FromJson(File.ReadAllText(gameSavePath), typeof(PlayerDataSave)) as PlayerDataSave;
		if (save == null)
		{
			GiveStarterPack();
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

	public void GetReward(Reward reward)
	{
		Money += reward.Money;
		SaveData();
		NotifyChanges();
	}

	private void NotifyChanges()
	{
		MoneyChanged?.Invoke(this, Money);
	}

	private void GiveStarterPack()
	{
		Money = 100;
		foreach((var uid, var upgrade) in AllUpgrades)
		{
			upgrade.SetLevel(0);
		}
	}

	public bool CanUpgrade(int moneyToSpent)
	{
		return moneyToSpent <= Money;
	}

	private void OnSceneChange(Scene scene)
	{
		so.Set(this);
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
