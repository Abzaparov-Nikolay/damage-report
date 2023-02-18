using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnCollisionEvent : MonoBehaviour
{
    [SerializeField] private int collisionsBeforeCall;
    [SerializeField] private UnityEvent onCollision;
    private int currentCollisionCount;

    private void OnCollisionEnter(Collision other)
    {
        currentCollisionCount++;

        if (currentCollisionCount == collisionsBeforeCall)
        {
            onCollision?.Invoke();
        }
    }
}