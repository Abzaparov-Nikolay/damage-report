using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTouch : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector2> beginTouchEvent;
    void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }
        var touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            beginTouchEvent?.Invoke(touch.position);
            return;
        }
    }
}
