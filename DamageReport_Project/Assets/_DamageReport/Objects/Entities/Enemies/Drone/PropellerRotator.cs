using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerRotator : MonoBehaviour
{
    private enum Direction
    {
        Positive = 1,
        Negative = -1
    }
    [SerializeField] private List<GameObject> propellers;
    [Tooltip("In degrees per second")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Direction rotationDirection;

    void Update()
    {
        foreach (var p in propellers)
        {
            p.transform.Rotate(new Vector3(0, (int)rotationDirection * Time.deltaTime * rotationSpeed, 0));
        }
    }
}
