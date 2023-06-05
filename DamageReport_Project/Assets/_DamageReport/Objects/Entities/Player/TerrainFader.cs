using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainFader : MonoBehaviour
{
	[SerializeField] private bool useRaycast = true;
	[SerializeField] private bool useTrigger = true;

	public Variable<Transform> Camera;
	private RaycastHit[] hits = new RaycastHit[8];
	public LayerMask layer;
	//public float raycastDistance;

	private void Update()
	{
		if (!useRaycast)
			return;

		var hittedAmount = Physics.RaycastNonAlloc(origin: gameObject.transform.position,
			direction: (Camera.Value.position - gameObject.transform.position).normalized,
			results: hits,
			maxDistance: (Camera.Value.position - gameObject.transform.position ).magnitude,
			layerMask: layer);
		for (var i = 0; i < hittedAmount; i++)
		{
			if (hits[i].collider.gameObject.TryGetComponent<TransparencyChanger>(out var changer))
			{
				changer.Call();
			}
		}
	}

	public void ShowTerrainObject(GameObject terrain)
	{
		if (!useTrigger)
			return;
		if (terrain.TryGetComponent<TransparencyChanger>(out var transparencyChanger))
		{
			transparencyChanger.TriggerCall(false);
		}
	}

	public void HideTerrainObject(GameObject terrain)
	{
		if (!useTrigger)
			return;
		if (terrain.TryGetComponent<TransparencyChanger>(out var transparencyChanger))
		{
			transparencyChanger.TriggerCall(true);
		}
	}
}
