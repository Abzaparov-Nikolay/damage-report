using System.Xml.XPath;
using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    [SerializeField] private bool spawnAsChild;
    [SerializeField] private Reference<GameObject> prefab;
    [SerializeField] private GameObject parent;
    [SerializeField] private Vector3 sizeMultiplier = new Vector3(1, 1, 1);

    public void Spawn()
    {
        GameObject result;
        if (spawnAsChild)
        {
            if (parent == null)
                result = Instantiate(prefab.Value, transform);
            else
                result = Instantiate(prefab.Value, parent.transform);
        }
        else
        {
            if (parent == null)
                result = Instantiate(prefab.Value);
            else
                result = Instantiate(prefab.Value, parent.transform.position, Quaternion.identity);
        }
        result.transform.localScale = new Vector3(  result.transform.localScale.x * sizeMultiplier.x,
                                                    result.transform.localScale.y * sizeMultiplier.y,
                                                    result.transform.localScale.z * sizeMultiplier.z);
    }
}
