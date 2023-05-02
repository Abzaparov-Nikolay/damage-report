using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private Variable<Vector2> inputDirection;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float brakingFriction;
    [SerializeField] private float maxRotation;
    [SerializeField] private float skidThreshold;

    public bool IsBraking { get; private set; }

    public bool IsSkidding { get; private set; }


    private void FixedUpdate()
    {
        var forwardVelocity = Vector3.Dot(transform.forward, body.velocity) * transform.forward;
        forwardVelocity = Vector3.ClampMagnitude(forwardVelocity, maxSpeed);
        var lateralVelocity = body.velocity - forwardVelocity;
        IsSkidding = lateralVelocity.magnitude > skidThreshold;
        lateralVelocity *= 1 - brakingFriction;
        body.velocity = forwardVelocity + lateralVelocity;

        if (inputDirection == Vector2.zero)
        {
            IsBraking = true;
            body.velocity *= 1 - brakingFriction;
            return;
        }
        IsBraking = false;

        var directionError = Vector2.SignedAngle(inputDirection.Value, transform.forward.Xz());
        directionError = Mathf.Clamp(directionError, -maxRotation, maxRotation);
        transform.Rotate(0, directionError, 0);

        if (body.velocity.magnitude < maxSpeed)
        {
            body.AddForce(acceleration * transform.forward);
        }
    }
}