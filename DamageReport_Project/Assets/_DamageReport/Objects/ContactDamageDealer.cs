using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ContactDamageDealer : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponentInParent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
