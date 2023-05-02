using UnityEngine;

public class WheelTrailController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private TrailRenderer trailRenderer;

    private void FixedUpdate()
    {
        trailRenderer.emitting = playerMovement.IsBraking || playerMovement.IsSkidding;
    }
}
