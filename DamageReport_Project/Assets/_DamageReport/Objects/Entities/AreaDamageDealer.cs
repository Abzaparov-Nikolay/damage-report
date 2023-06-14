using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamageDealer : MonoBehaviour
{
    [SerializeField] private AreaTracker areaTracker;
    [SerializeField] private Reference<float> baseDamage;
    [SerializeField] private Reference<float> multiplier;
    [SerializeField] private Team team;

    public void Deal()
    {
        foreach(var entity in areaTracker)
        {
            if (entity.gameObject.TryGetComponentInParent<TeamMember>(out var otherTeamMember)
                && team.IsHostileTo(otherTeamMember.Team)
                && entity.gameObject.TryGetComponentInParent<Health>(out var health))
            {
                health.TakeDamage(baseDamage * multiplier);
            }
        }
    }
}
