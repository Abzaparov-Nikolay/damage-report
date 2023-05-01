using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private bool spawnAsChild;
    [SerializeField] private GameObject prefab;

    public void Spawn()
    {
        if (spawnAsChild)
        {
            Instantiate(prefab, transform);
        }
        else
        {
            Instantiate(prefab);
        }
    }
}
