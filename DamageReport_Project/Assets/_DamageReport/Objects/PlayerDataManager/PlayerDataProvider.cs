using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataProvider : MonoBehaviour
{
	[SerializeField] private Variable<PlayerData> playerDataVariable;
	[SerializeField] private PlayerData playerData;
	private void Awake()
	{
		playerDataVariable.Set(playerData);
	}
}
