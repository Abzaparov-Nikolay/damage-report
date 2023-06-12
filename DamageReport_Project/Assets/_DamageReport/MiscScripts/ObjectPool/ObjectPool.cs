using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int startAmount;
    public int readonlyAmountInPool;
    private Stack<GameObject> objects = new();

    private void Update()
    {
        readonlyAmountInPool = objects.Count;
    }

    public GameObject Get()
    {
        if (objects.Count > 0)
        {
            var obj = objects.Pop();
            obj.SetActive(true);
            if (obj.TryGetComponent<PoolMember>(out var member))
                member.Initialize();
            return obj;
        }
        else 
            return CreateNew();
    }

    public void Return(GameObject obj)
    {
        if (obj.TryGetComponent<PoolMember>(out var member))
            member.DeInitialize();
        obj.SetActive(false);
        objects.Push(obj);
    }

    private GameObject CreateNew()
    {
        return Instantiate(prefab);
    }

    private void OnEnable()
    {
        for (var i = 0; i < startAmount; i++)
        {
            var newObj = CreateNew();
            newObj.SetActive(false);
            objects.Push(newObj);
        }
    }

    private void OnDisable()
    {
        while (objects.Count > 0)
        {
            Destroy(objects.Pop());
        }
    }
}
