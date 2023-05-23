using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookThroughWalls : MonoBehaviour
{
	public Reference<Transform> player;
	public RaycastHit[] hits = new RaycastHit[8];
	public LayerMask layer;
	public float raycastDistance;

	private void Update()
	{
		var hittedAmount = Physics.RaycastNonAlloc(player.Value.position, (gameObject.transform.position - player.Value.position ).normalized, hits, raycastDistance, layer);
		for (var i = 0; i < hittedAmount; i++)
		{
			if(hits[i].collider.gameObject.TryGetComponent<TransparencyChanger>(out var changer))
			{
				changer.Call();
			}
		}
	}
}
