using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
	//[SerializeField] private float Width = 300;
	[SerializeField] private float xPos = 0;
	//[SerializeField] private float Length = 500;
	[SerializeField] private float zPos = 0;
	[SerializeField] private Reference<Vector3> mapSize;
	[SerializeField] private int pillarsSpawnAmount = 100;
	[SerializeField] private int raycastTries = 2;
	[SerializeField] private float raycastSphereRadius = 10;
	public LayerMask layer;
	public GameObject pillarPrefab;
	public GameObject fencePrefab;
	public Transform TerrainParent;

	private RaycastHit[] hits = new RaycastHit[1];
	void Start()
	{
		SpawnFence();
		SpawnPillars();
	}

	private void SpawnPillars()
	{
		for (var j = 0; j < pillarsSpawnAmount; j++)
		{
			for (var i = 0; i < raycastTries; i++)
			{
				var position = new Vector3(xPos + (mapSize.Value.x * (Random.value - 0.5f)), 0, zPos + (mapSize.Value.z * (Random.value - 0.5f)));
				var hitsCount = Physics.SphereCastNonAlloc(position, raycastSphereRadius, Vector3.one.normalized, hits, 0, layer);
				if (hitsCount == 0)
				{
					Instantiate(pillarPrefab, position, Quaternion.identity, TerrainParent);
					break;
				}
			}
		}
	}

	private void SpawnFence()
	{
		foreach (var mirror in new[] { -1, 1 })
		{
			foreach (var xzMultiplier in new[] { (x: 0, z: 1), (x: 1, z: 0) })
			{
				var position = new Vector3(mirror * xzMultiplier.x * mapSize.Value.x / 2,
					0,
					mirror * xzMultiplier.z * mapSize.Value.z / 2);
				//var rotation = Quaternion.Euler(0, 90 * xzMultiplier.x, 0);
				var rotation = Quaternion.identity;
				var fence = Instantiate(fencePrefab, position, rotation, TerrainParent);
				var scale = new Vector3(1 + mapSize.Value.x * xzMultiplier.z,
					fence.transform.localScale.y,
					1 + mapSize.Value.z * xzMultiplier.x);
				//fence.transform.localScale.x = 1 + mapSize.Value.z * xzMultiplier;
				//fence.transform.localScale.Set(scale);
				fence.transform.localScale = scale;
			}
		}
	}
}
