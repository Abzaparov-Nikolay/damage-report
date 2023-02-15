using System;
using UnityEngine;

public abstract class ReadVariable<T> : ScriptableObject
{
    public abstract T Get();

    public static implicit operator T(ReadVariable<T> v) => v.Get();
}

public abstract class Variable<T> : ReadVariable<T>
{
    [SerializeField] protected T initialValue;

    [Header(Headers.Runtime)]
    [SerializeField, RuntimeRW] protected T value;

    public event Action OnChanged;
    public event Action<T> OnChangedWithOldValue;

    public override T Get() => value;

    public void Set(T newValue)
    {
        var oldValue = value;
        value = newValue;
        OnChanged?.Invoke();
        OnChangedWithOldValue?.Invoke(oldValue);
    }

    private void OnEnable()
    {
        Set(initialValue);
    }

    public static implicit operator T(Variable<T> v) => v.Get();
}