using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamageDealer : MonoBehaviour
{
    [SerializeField] private AreaTracker areaTracker;
    [SerializeField] private Reference<float> damage;
    [SerializeField] private Team team;

    public void Deal()
    {
        foreach(var entity in areaTracker)
        {
            if (entity.gameObject.TryGetComponent<TeamMember>(out var otherTeamMember)
                && team.IsHostileTo(otherTeamMember.Team)
                && entity.gameObject.TryGetComponentInParent<Health>(out var health))
            {
                health.TakeDamage(damage);
            }
        }
    }
}
