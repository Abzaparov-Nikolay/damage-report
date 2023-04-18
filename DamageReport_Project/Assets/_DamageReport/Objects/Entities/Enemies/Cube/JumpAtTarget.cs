using UnityEngine;

public class JumpAtTarget : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private Variable<Transform> target;
    [SerializeField] private float interval;
    [SerializeField] private float impulse;
    [SerializeField] private float verticalAngle;

    private float timeSinceLastJump;

    private void FixedUpdate()
    {
        timeSinceLastJump += Time.fixedDeltaTime;
        if (timeSinceLastJump > interval)
        {
            Jump();
            timeSinceLastJump -= interval;
        }
    }

    private void Jump()
    {
        var direction = target.Get().position - body.position;
        direction.y = 0;
        direction.Normalize();
        direction = Quaternion.AngleAxis(verticalAngle, Vector3.Cross(direction, Vector3.up)) * direction;
        body.AddForce(impulse * direction, ForceMode.Impulse);
    }
}
