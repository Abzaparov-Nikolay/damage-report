using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackDealer : MonoBehaviour
{
    [SerializeField] private TeamMember teamMember;
    [SerializeField] private float impulse;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponentInParent<TeamMember>(out var otherTeamMember) 
            && otherTeamMember.IsHostileTo(teamMember))
        {
            var impulseVector = (otherTeamMember.transform.position - transform.position).normalized * impulse;


            if (otherTeamMember.TryGetComponent<Rigidbody>(out var otherBody))
            {
                otherBody.AddForce(impulseVector, ForceMode.Impulse);
            }
            else if(otherTeamMember.TryGetComponent<PlayerKnockbackReceiver>(out var playerKnockbackReceiver))
            {
                playerKnockbackReceiver.ReceiveKnockback(impulseVector);
            }
        }
    }
}
