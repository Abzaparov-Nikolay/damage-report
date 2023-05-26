using UnityEngine;

public class HoverTankMovement : MonoBehaviour
{
    [SerializeField] private Variable<Transform> target;
    [SerializeField] private Rigidbody body;
    [SerializeField] private float speed;
    [SerializeField] private float stopRadius;
    [SerializeField][Range(0.0f, 1.0f)] private float rotationSpeed;
    
    private void FixedUpdate()
    {
        
        //if(Vector3.Angle(body.transform.up, Vector3.up) > 60)
        //{
        //    var rotGoal = Quaternion.LookRotation(Vector3.up);

        //    transform.rotation = Quaternion.Lerp(transform.rotation, rotGoal, 0.2f);
        //}

        var direction = (target.Get().position - body.position);
        direction.y = 0;
        direction.Normalize();
        if (Vector3.Angle(body.transform.forward, direction) > 30)
        {
            var rotGoal = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotGoal, rotationSpeed * Time.fixedDeltaTime);
        }
        else if ((body.position - target.Get().position).magnitude > stopRadius)
        {
            body.position += speed * Time.fixedDeltaTime * body.transform.forward;
        }
    }
}
