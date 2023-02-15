using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ReadVariable<Vector2> inputDirection;
    [SerializeField] private float speed;

    private void FixedUpdate()
    {
        Vector3 moveDirection = new(inputDirection.Get().x, 0, inputDirection.Get().y);
        transform.position += speed * Time.fixedDeltaTime * moveDirection;
    }
}