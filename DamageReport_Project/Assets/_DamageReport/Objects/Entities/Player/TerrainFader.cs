using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFader : MonoBehaviour
{
	public void ShowTerrainObject(GameObject terrain)
	{
		if(terrain.TryGetComponent<TransparencyChanger>(out var transparencyChanger))
		{
			transparencyChanger.BecomeVisible();
		}
	}

	public void HideTerrainObject(GameObject terrain)
	{
		if (terrain.TryGetComponent<TransparencyChanger>(out var transparencyChanger))
		{
			transparencyChanger.BecomeTransperent();
		}
	}
}
