using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject, IEnumerable<T> where T : UnityEngine.Object
{
    protected readonly HashSet<T> items = new();

    public event Action OnAdded;
    public event Action OnRemoved;

    public int Count => items.Count;

    public virtual void Add(T item)
    {
        items.Add(item);
        OnAdded?.Invoke();
    }

    public virtual void Remove(T item)
    {
        items.Remove(item);
        OnRemoved?.Invoke();
    }

    public void DestroyAll()
    {
        foreach(var item in items.ToList())
        {
            Remove(item);
            Destroy(item);
        }
    }

    public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
