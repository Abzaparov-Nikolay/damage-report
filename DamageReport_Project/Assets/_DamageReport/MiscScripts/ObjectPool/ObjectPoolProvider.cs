using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolProvider : MonoBehaviour
{
    [SerializeField] private Variable<ObjectPool> objectPoolVariable;
    [SerializeField] private ObjectPool objectPool;

    private void Awake()
    {
        objectPoolVariable.Set(objectPool);
    }
}
