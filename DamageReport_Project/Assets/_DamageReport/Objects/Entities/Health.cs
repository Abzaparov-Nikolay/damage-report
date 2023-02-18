using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public Reference<float> Max;
    public Reference<float> Current;
    [SerializeField] private UnityEvent onDamaged;
    [SerializeField] private UnityEvent onCurrentZero;

    public void TakeDamage(float damage)
    {
        Current.Set(Current - damage);
        if (Current > 0)
        {
            onDamaged?.Invoke();
        }
        else
        {
            onCurrentZero.Invoke();
        }
    }

    private void OnEnable()
    {
        Current.Set(Max);
    }
}
