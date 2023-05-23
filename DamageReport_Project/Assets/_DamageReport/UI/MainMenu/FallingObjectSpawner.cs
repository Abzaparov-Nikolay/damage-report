using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private float spawnInterval;
    [SerializeField] private BoxCollider spawnLocation;

    private float timeSinceLastSpawn;

    private void Start()
    {
        Spawn();
    }

    private void FixedUpdate()
    {
        timeSinceLastSpawn += Time.fixedDeltaTime;
        if (timeSinceLastSpawn < spawnInterval)
            return;

        timeSinceLastSpawn = 0;
        Spawn();
    }

    private void Spawn()
    {
        var min = -spawnLocation.size / 2;
        var max = spawnLocation.size / 2;
        var spawnPosition = new Vector3(
            Mathf.Lerp(min.x, max.x, Random.value),
            Mathf.Lerp(min.y, max.y, Random.value),
            Mathf.Lerp(min.z, max.z, Random.value));
        spawnPosition = spawnLocation.transform.rotation * spawnPosition;
        spawnPosition += spawnLocation.transform.position + spawnLocation.center;
        Instantiate(cubePrefab, spawnPosition, Random.rotation);
    }
}
