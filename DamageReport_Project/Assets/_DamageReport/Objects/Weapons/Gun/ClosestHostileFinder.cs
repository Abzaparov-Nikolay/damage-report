using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClosestHostileFinder : TargetSelector
{
    [SerializeField] private Team team;
    [SerializeField] private AreaTracker areaTracker;

    public override bool TryGetTarget(out Transform target)
    {
        target = areaTracker
			.Where(entity => entity != null && entity.gameObject.activeInHierarchy)
            .Where(entity => entity.gameObject.TryGetComponentInParent<TeamMember>(out var otherTeamMember) && team.IsHostileTo(otherTeamMember.Team))
			.MinBy(hostile => Vector3.Distance(transform.position, hostile.position));
        return target != null;
    }
}
