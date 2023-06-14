using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClosestHostileFinder : TargetSelector
{
    [SerializeField] private Team team;
    [SerializeField] private AreaTracker areaTracker;
    [SerializeField] private Transform direction;
    public override bool TryGetTarget(out Transform target)
    {
        target = areaTracker
			.Where(entity => entity != null 
                            && entity.gameObject.activeInHierarchy
                            && entity.gameObject.TryGetComponentInParent<TeamMember>(out var otherTeamMember)
                            && team.IsHostileTo(otherTeamMember.Team)
                            && (direction == null || direction != null && Vector3.Dot(direction.forward, (entity.position - direction.position).normalized) > 0))
			.MinBy(hostile => Vector3.Distance(transform.position, hostile.position));
        return target != null;
    }
}
