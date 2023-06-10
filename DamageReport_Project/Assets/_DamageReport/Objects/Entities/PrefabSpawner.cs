using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private bool spawnAsChild;
    [SerializeField] private Reference<GameObject> prefab;
    [SerializeField] private GameObject parent;
    public void Spawn()
    {
        if (spawnAsChild)
        {
            if (parent == null)
                Instantiate(prefab.Value, transform);
            else
                Instantiate(prefab.Value, parent.transform);
        }
        else
        {
            if (parent == null)
                Instantiate(prefab.Value);
            else
                Instantiate(prefab.Value, parent.transform.position, Quaternion.identity);
        }
    }
}
