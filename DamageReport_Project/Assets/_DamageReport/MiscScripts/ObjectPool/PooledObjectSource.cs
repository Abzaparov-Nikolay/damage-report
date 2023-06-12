using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObjectSource : MonoBehaviour
{
    [SerializeField] private Reference<ObjectPool> pool;
    [SerializeField] private GameObject prefab;
    [SerializeField] private bool usePrefab;

    public GameObject Get()
    {
        if (usePrefab)
        {
            return Instantiate(prefab);
        }
        else
        {
            return pool.Get().Get();
        }
    }
}
