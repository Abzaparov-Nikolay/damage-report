using UnityEngine;

public class AccelerateTowardsTarget : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private ReadVariable<Transform> target;
    [SerializeField] private float force;

    private void FixedUpdate()
    {
        var direction = target.Get().position - body.position;
        direction.y = 0;
        direction.Normalize();
        body.AddForce(force * direction, ForceMode.Force);
    }
}
