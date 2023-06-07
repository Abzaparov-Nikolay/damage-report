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

	private Dictionary<string, Upgrade> AllUpgrades;
	public int Money { get; private set; }

	private string gameSavePath;

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

		gameSavePath = Application.persistentDataPath + "/game_save.json";
		AllUpgrades = new Dictionary<string, Upgrade>();
		foreach(var upgrade in upgradesList)
		{
			AllUpgrades.Add(upgrade.UID, upgrade);
		}
		//AllUpgrades = Resources.LoadAll<Upgrade>("RuntimeSO/Upgrades").ToDictionary(i => i.guid);
	}

	private void Start()
	{
		LoadUpgrades();
	}

	

	private void LoadUpgrades()
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

	public void SaveUpgrades()
	{
		var save = GeneratePlayerSave();
		var jsonSave = JsonUtility.ToJson(save);

		if (!File.Exists(gameSavePath))
		{
			var file = File.Create(gameSavePath);
			file.Close();
		}
		File.WriteAllText(gameSavePath, jsonSave);
	}

	private PlayerDataSave GeneratePlayerSave()
	{
		var save = new PlayerDataSave();
		save.money = Money;
		foreach( ( var guid, var upgrade) in AllUpgrades)
		{
			save.AddUpgrade(upgrade);
		}
		return save;
	}

	private void CreateBasicSaves()
	{

	}
}
