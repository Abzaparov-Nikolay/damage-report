using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(Collider))]
public class ClosestHostileFinder : TargetSelector
{
    [SerializeField] private Reference<float> range;
    [SerializeField] private TeamMember teamMember;
    [SerializeField] private bool shootBullets;

    private readonly HashSet<Transform> hostilesInRange = new();
    private new Collider collider;

    public override bool TryGetTarget(out Transform target)
    {
        target = hostilesInRange
			.Where(hostile => hostile != null && hostile.gameObject.activeInHierarchy)
			.MinBy(hostile => Vector3.Distance(transform.position, hostile.position));
        return target != null;
    }

    private void Awake()
    {
        collider = GetComponent<Collider>();
        if (!collider.isTrigger)
            collider.isTrigger = true;
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
        if (collider is SphereCollider)
        {
            var sphereCollider = collider as SphereCollider;
            sphereCollider.radius = range;
        }
        else if (collider is CapsuleCollider)
        {
            var capsuleCollider = collider as CapsuleCollider;
            capsuleCollider.radius = range;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var otherTeamMember = other.GetComponentInParent<TeamMember>();
        if (otherTeamMember != null 
            && teamMember.IsHostileTo(otherTeamMember)
            && other.gameObject.activeInHierarchy
            && (shootBullets || other.GetComponent<Projectile>() == null))
        {
            hostilesInRange.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hostilesInRange.Remove(other.transform);
    }
}
