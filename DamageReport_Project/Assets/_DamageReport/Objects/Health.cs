using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public Reference<float> Max;
    public Reference<float> Current;
    public UnityEvent OnDamaged;
    public UnityEvent OnDeath;

    public void TakeDamage(float damage)
    {
        Current.Set(Current - damage);
        if (Current > 0)
        {
            OnDamaged?.Invoke();
        }
        else
        {
            OnDeath.Invoke();
        }
    }

    private void OnEnable()
    {
        Current.Set(Max);
    }
}
