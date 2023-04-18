using UnityEngine;

public class ExperienceParticle : MonoBehaviour
{
    [field: SerializeField] public Reference<float> Value { get; private set; }

    [SerializeField] private Reference<float> attractionForce;
    [SerializeField] private Reference<float> startJumpImpulse;
    [SerializeField] private Rigidbody body;

    public bool IsAttracting { get; private set; }

    private Transform target;

    public void StartAttracting(Transform target)
    {
        body.AddForce(startJumpImpulse * Vector3.up, ForceMode.Impulse);
        body.useGravity = false;
        IsAttracting = true;
        this.target = target;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            var direction = (target.transform.position - transform.position).normalized;
            body.AddForce(attractionForce * direction);
        }
    }
}
