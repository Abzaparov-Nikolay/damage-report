using UnityEngine;

public class TouchInputProvider : MonoBehaviour
{
    [Header(Headers.Output)]
    [SerializeField] private Variable<Vector2> inputDirection;

    private Vector2 touchStartPosition;

    private void Update()
    {
        if (Input.touchCount == 0 )
        {
            return;
        }
        var touch = Input.touches[0];
        if (touch.phase == TouchPhase.Began)
        {
            touchStartPosition = touch.position;
            return;
        }
        if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            inputDirection.Set(default);
            return;
        }
        inputDirection.Set((touch.position - touchStartPosition).normalized);
    }
}
