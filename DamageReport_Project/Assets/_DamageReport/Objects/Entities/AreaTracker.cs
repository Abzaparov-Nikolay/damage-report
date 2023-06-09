using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AreaTracker : MonoBehaviour, IEnumerable<Transform>
{
	[SerializeField] private Reference<float> rangeMultiplier;
	[SerializeField] private Reference<float> baseRange;
	[SerializeField] private new Collider collider;
	[SerializeField] private Team team;
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
		rangeMultiplier.OnChanged += ChangeColliderRadius;
		ChangeColliderRadius();
	}

	private void OnDisable()
	{
		rangeMultiplier.OnChanged -= ChangeColliderRadius;
	}

	private void ChangeColliderRadius()
	{
		if (collider is SphereCollider)
		{
			var sphereCollider = collider as SphereCollider;
			sphereCollider.radius = baseRange * rangeMultiplier;
		}
		else if (collider is CapsuleCollider)
		{
			var capsuleCollider = collider as CapsuleCollider;
			capsuleCollider.radius = baseRange * rangeMultiplier;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.activeInHierarchy
			&& other.gameObject.TryGetComponentInParent<TeamMember>(out var otherTeamMember)
			&& team.IsHostileTo(otherTeamMember.Team))
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
