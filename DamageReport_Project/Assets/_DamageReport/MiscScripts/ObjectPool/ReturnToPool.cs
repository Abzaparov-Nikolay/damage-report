using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    [SerializeField] private Reference<ObjectPool> pool;
    public void Return()
    {
        if (pool != null && pool.IsValid())
            pool.Get().Return(gameObject);
        else 
            Destroy(gameObject);
    }
}
