using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HoverTankMovement : MonoBehaviour
{
    [SerializeField] private ReadVariable<Transform> target;
    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed;
    [SerializeField] private float stopRadius;
    [SerializeField][Range(0.0f, 1.0f)] private float rotationSpeed;

    private void FixedUpdate()
    {
           
        var direction = (target.Get().position - body.position);
        direction.y = 0;
        direction.Normalize();
        if (Vector3.Angle(body.transform.forward ,direction) > 30)
        {
            var rotGoal = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotGoal, rotationSpeed * Time.fixedDeltaTime);
        }
        if((body.position - target.Get().position).magnitude > stopRadius)
        {
            body.position += speed * Time.fixedDeltaTime * body.transform.forward;
        }


    }
}
