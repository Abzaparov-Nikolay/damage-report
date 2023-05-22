using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> onTrigger;
    [SerializeField] private UnityEvent<GameObject> onTriggerExit;
    [SerializeField] private TeamMember teamMember;
    private void OnTriggerEnter(Collider other)
    {
        if (teamMember != null && other.gameObject.TryGetComponentInParent<TeamMember>(out var otherTeamMember) && otherTeamMember.Team == teamMember.Team)
            return;
        onTrigger?.Invoke(other.gameObject);
    }

	private void OnTriggerExit(Collider other)
	{
		if (teamMember != null && other.gameObject.TryGetComponentInParent<TeamMember>(out var otherTeamMember) && otherTeamMember.Team == teamMember.Team)
			return;
		onTriggerExit?.Invoke(other.gameObject);
	}
}
