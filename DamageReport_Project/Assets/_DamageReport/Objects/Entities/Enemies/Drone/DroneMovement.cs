using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] private Variable<Transform> target;
    [SerializeField] private float speed;
    [SerializeField] private float stopRadius;
    [SerializeField][Range(0.0f, 1.0f)] private float tiltSpeed;
    private Rigidbody body;
    private Quaternion normalRotation;
    private Quaternion targetRotation;
    private bool movingToTarget = false;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        normalRotation = transform.rotation;
    }

    void Update()
    {
        if ((body.position.Xz() - target.Get().position.Xz()).magnitude > stopRadius)
        {
            var directionToTarget = (target.Get().position - transform.position);
            directionToTarget.y = 0;
            directionToTarget.Normalize();
            if (movingToTarget)
            {
                var left = Vector3.Cross(directionToTarget, Vector3.up);
                targetRotation = normalRotation * Quaternion.AngleAxis(-15, left);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, tiltSpeed * Time.deltaTime);
            }
            else
            {
                movingToTarget = true;
            }
            
        }
        else
        {
            if (movingToTarget) { 
                movingToTarget = false;
            }
            else
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, normalRotation, tiltSpeed * Time.deltaTime);
            }
        }
    }

    private void FixedUpdate()
    {
        
        if (movingToTarget)
        {
            var directionToTarget = (target.Get().position - transform.position);
            directionToTarget.y = 0;
            directionToTarget.Normalize();
            body.position += speed * Time.fixedDeltaTime * directionToTarget;
        }
    }
}
