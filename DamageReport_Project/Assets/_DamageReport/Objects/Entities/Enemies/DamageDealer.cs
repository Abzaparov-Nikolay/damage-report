using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private Reference<float> damage;

    public void Deal(GameObject target)
    {
        if (target.TryGetComponentInParent<Health>(out var health))
        {
            health.TakeDamage(damage);
            //Debug.Log(damage.Get().ToString());
        }
    }
}
