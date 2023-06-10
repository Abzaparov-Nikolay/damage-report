using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HovertankPlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody body;
    [SerializeField] private Variable<Vector2> inputDirection;
    [SerializeField] private Reference<float> acceleration;
    [SerializeField] private Reference<float> maxSpeed;
    [SerializeField] private float brakingFriction;
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (inputDirection == Vector2.zero)
        {
            body.velocity *= 1 - brakingFriction * Time.fixedDeltaTime;
            return;
        }
        body.AddForce(acceleration * inputDirection.Get().AsXz());
        body.velocity = Vector3.ClampMagnitude(body.velocity, maxSpeed);
    }
}
