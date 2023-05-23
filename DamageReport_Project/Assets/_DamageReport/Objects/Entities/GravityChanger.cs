using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float gravity;
    [SerializeField] private Rigidbody body;

    private void FixedUpdate()
    {
        body.AddForce(-Physics.gravity * (1 - gravity), ForceMode.Acceleration);
    }
}
