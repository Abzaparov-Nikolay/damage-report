using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ClosestHostileFinder : TargetSelector
{
    [SerializeField] private Reference<float> range;
    [SerializeField] private TeamMember teamMember;

    private readonly HashSet<Transform> hostilesInRange = new();
    private SphereCollider sphereCollider;

    public override Transform GetTarget()
    {
        return hostilesInRange.MinBy(hostileTransform => Vector3.Distance(transform.position, hostileTransform.position));
    }

    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnEnable()
    {
        range.OnChanged += ChangeColliderRadius;
        ChangeColliderRadius();
    }

    private void OnDisable()
    {
        range.OnChanged -= ChangeColliderRadius;
    }

    private void ChangeColliderRadius()
    {
        sphereCollider.radius = range;
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherTeamMember = other.GetComponentInParent<TeamMember>();
        if (otherTeamMember != null && teamMember.IsHostileTo(otherTeamMember))
        {
            hostilesInRange.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hostilesInRange.Remove(other.transform);
    }
}
