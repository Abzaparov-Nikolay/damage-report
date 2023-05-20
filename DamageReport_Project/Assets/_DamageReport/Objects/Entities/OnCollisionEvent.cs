using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class OnCollisionEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> onCollision;
    [SerializeField] private TeamMember teamMember;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponentInParent<TeamMember>(out var otherTeamMember) && otherTeamMember.Team == teamMember.Team)
            return;
        onCollision?.Invoke(other.gameObject);
    }
}