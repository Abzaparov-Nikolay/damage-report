using System.Collections.Generic;
using UnityEngine;

public class WheelTurner : MonoBehaviour
{
    [SerializeField] private List<Transform> frontWheels;
    [SerializeField] private List<Transform> backWheels;
    [SerializeField] private BasicPlayerMovement movement;
    [SerializeField] private float turnAngle;
    [SerializeField, Range(0, 1)] private float turnInertia;

    public void Update()
    {
        var wheelTurn = Mathf.InverseLerp(-movement.MaxTurn, movement.MaxTurn, movement.CurrentTurning);
        wheelTurn = (wheelTurn - 0.5f) * 2;
        for (var i = 0; i < frontWheels.Count; i++)
        {
            RotateWheel(frontWheels[i], true);
        }
        for (var i = 0; i < backWheels.Count; i++)
        {
            RotateWheel(backWheels[i], false);
        }

        void RotateWheel(Transform wheel, bool isFrontWheel)
        {
            var turnSign = isFrontWheel ? 1 : -1;
            wheel.transform.localRotation = Quaternion.Lerp(
                wheel.transform.localRotation,
                Quaternion.Euler(0, turnSign * wheelTurn * turnAngle, 0),
                1 - turnInertia);
        }
    }
} 
