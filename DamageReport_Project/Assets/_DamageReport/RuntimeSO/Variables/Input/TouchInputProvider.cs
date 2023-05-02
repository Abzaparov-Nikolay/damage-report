using UnityEngine;

public class TouchInputProvider : MonoBehaviour
{
    [Header(Headers.Input)]
    [SerializeField] private Variable<Camera> mainCamera;

    [Header(Headers.Output)]
    [SerializeField] private Variable<Vector2> inputDirection;

    private Vector2 touchStartPosition;

    private void Update()
    {
        if (Input.touchCount == 0 )
        {
            return;
        }
        var touch = Input.GetTouch(0);
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
        var screenInputDirection = (touch.position - touchStartPosition).normalized;
        var worldInputDirection = screenInputDirection.Rotate(-mainCamera.Value.transform.rotation.eulerAngles.y);
        inputDirection.Set(worldInputDirection);
    }
}
