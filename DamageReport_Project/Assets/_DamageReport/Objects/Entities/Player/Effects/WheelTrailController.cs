using System.Collections.Generic;
using UnityEngine;

public class WheelTrailController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private List<TrailRenderer> renderers;

    private void FixedUpdate()
    {
        for (var i = 0; i < renderers.Count; i++)
        {
            renderers[i].emitting = playerMovement.IsBraking || playerMovement.IsSkidding;
        }
    }
}
