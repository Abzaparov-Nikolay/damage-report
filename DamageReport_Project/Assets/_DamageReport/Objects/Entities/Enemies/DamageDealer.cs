using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private Reference<float> baseDamage;
    [SerializeField] private Reference<float> multiplier;

    public void Deal(GameObject target)
    {
        if (target.TryGetComponentInParent<Health>(out var health))
        {
            health.TakeDamage(baseDamage * multiplier);
            //Debug.Log(damage.Get().ToString());
        }
    }
}
