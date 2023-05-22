using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private bool spawnAsChild;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject parent;
    public void Spawn()
    {
        if (spawnAsChild)
        {
            if (parent == null)
                Instantiate(prefab, transform);
            else
                Instantiate(prefab, parent.transform);
        }
        else
        {
            if (parent == null)
                Instantiate(prefab);
            else
                Instantiate(prefab, parent.transform.position, Quaternion.identity);
        }
    }
}
