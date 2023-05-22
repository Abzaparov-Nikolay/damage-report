using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AreaTracker : MonoBehaviour, IEnumerable<Transform>
{
    [SerializeField] private Reference<float> range;
    [SerializeField] private new Collider collider;
    private readonly HashSet<Transform> entitiesInRange = new();
    private void Start()
    {
        if (collider == null)
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
        if (other.gameObject.activeInHierarchy)
        {
            entitiesInRange.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        entitiesInRange.Remove(other.transform);
    }

    public IEnumerator<Transform> GetEnumerator() => entitiesInRange.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
