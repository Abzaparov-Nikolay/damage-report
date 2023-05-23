using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
	[SerializeField] private float Width = 300;
	[SerializeField] private float xPos = 0;
	[SerializeField] private float Length = 500;
	[SerializeField] private float zPos = 0;
	[SerializeField] private int pillarsSpawnAmount = 100;
	[SerializeField] private int raycastTries = 2;
	[SerializeField] private float raycastSphereRadius = 10;
	public LayerMask layer;
	public GameObject pillarPrefab;
	public Transform TerrainParent;

	private RaycastHit[] hits = new RaycastHit[1];
	void Start()
	{
		for (var j = 0; j < pillarsSpawnAmount; j++)
		{
			for (var i = 0; i < raycastTries; i++)
			{
				var position = new Vector3(xPos + (Width * (Random.value - 0.5f)), 0, zPos + (Length * (Random.value - 0.5f)));
				var hitsCount = Physics.SphereCastNonAlloc(position, raycastSphereRadius, Vector3.one.normalized, hits, 0, layer);
				if (hitsCount == 0)
				{
					Instantiate(pillarPrefab, position, Quaternion.identity, TerrainParent);
					break;
				}
			}
		}
	}
}
