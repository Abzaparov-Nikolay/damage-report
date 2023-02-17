using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ContactDamageDealer : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private TeamMember teamMember;

    private void OnCollisionEnter(Collision collision)
    {
        var health = collision.gameObject.GetComponentInParent<Health>();
        var otherTeamMember = collision.gameObject.GetComponentInParent<TeamMember>();
        if (health != null && otherTeamMember != null && teamMember.IsHostileTo(otherTeamMember))
        {
            health.TakeDamage(damage);
        }
    }
}
