using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ReadVariable<Vector2> inputDirection;
    [SerializeField] private float speed;
    [SerializeField] private new Transform camera;

    private void FixedUpdate()
    {
        if (inputDirection == Vector2.zero)
        {
            return;
        }
        var worldUp = transform.position - camera.position;
        worldUp.y = 0;
        worldUp.Normalize();
        var moveAngle = Mathf.Atan2(inputDirection.Get().y, inputDirection.Get().x) * Mathf.Rad2Deg;
        var moveDirection = Quaternion.Euler(0, -moveAngle + 90, 0) * worldUp;
        transform.position += speed * Time.fixedDeltaTime * moveDirection;
    }
}