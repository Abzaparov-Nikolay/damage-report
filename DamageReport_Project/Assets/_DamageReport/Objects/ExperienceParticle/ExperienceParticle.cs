using System.Collections;
using UnityEngine;

public class ExperienceParticle : MonoBehaviour
{
    [field: SerializeField] public Reference<float> Value { get; private set; }

    [SerializeField] private Reference<float> startJumpImpulse;
    [SerializeField] private Rigidbody body;
    [SerializeField] private new Collider collider;
    [SerializeField] private float relativeSpeed;
    [SerializeField] private float acceleration;

    public bool IsAttracting { get; private set; }

    private Transform target;

    public void StartAttracting(Transform target)
    {
        body.AddForce(startJumpImpulse * Vector3.up, ForceMode.Impulse);
        body.useGravity = false;
        StartCoroutine(StartAttracting());
        collider.isTrigger = true;
        this.target = target;
    }

    IEnumerator StartAttracting()
    {
        yield return null;
        IsAttracting = true;
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            var movement = target.position - body.position;
            var targetVelocity = relativeSpeed * movement;
            var velocityError = targetVelocity - body.velocity;
            body.AddForce(acceleration * velocityError);
            if (body.position.y < 0)
            {
                body.AddForce(startJumpImpulse / 2 * Vector3.up, ForceMode.Impulse);
            }
        }
    }
}
