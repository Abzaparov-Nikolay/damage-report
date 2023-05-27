using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private Variable<Vector2> inputDirection;
    [SerializeField] private Reference<float> acceleration;
    [SerializeField] private Reference<float> maxSpeed;
    [SerializeField] private float brakingFriction;
    [field: SerializeField] public float MaxTurn { get; private set; }
    [SerializeField] private float skidThreshold;

    public bool IsBraking { get; private set; }

    public bool IsSkidding { get; private set; }

    public float CurrentTurning { get; private set; }

    private void FixedUpdate()
    {
        CurrentTurning = 0;

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
        directionError = Mathf.Clamp(directionError, -MaxTurn, MaxTurn);
        transform.Rotate(0, directionError, 0);
        CurrentTurning = directionError;

        if (body.velocity.magnitude < maxSpeed)
        {
            body.AddForce(acceleration * transform.forward);
        }
    }
}