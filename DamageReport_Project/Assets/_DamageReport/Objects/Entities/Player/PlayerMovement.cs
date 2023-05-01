using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private Variable<Vector2> inputDirection;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float brakingFriction;
    [SerializeField] private float maxRotation;

    private void FixedUpdate()
    {
        var forwardVelocity = Vector3.Dot(transform.forward, body.velocity) * transform.forward;
        forwardVelocity = Vector3.ClampMagnitude(forwardVelocity, maxSpeed);
        var lateralVelocity = body.velocity - forwardVelocity;
        lateralVelocity *= 1 - brakingFriction;
        body.velocity = forwardVelocity + lateralVelocity;

        if (inputDirection == Vector2.zero)
        {
            body.velocity *= 1 - brakingFriction;
            return;
        }

        var directionError = Vector2.SignedAngle(inputDirection.Value, transform.forward.Xz());
        directionError = Mathf.Clamp(directionError, -maxRotation, maxRotation);
        transform.Rotate(0, directionError, 0);

        if (body.velocity.magnitude < maxSpeed)
        {
            body.AddForce(acceleration * transform.forward);
        }
    }
}