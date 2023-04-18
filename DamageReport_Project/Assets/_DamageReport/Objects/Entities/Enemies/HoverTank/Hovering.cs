using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hovering : MonoBehaviour
{
    [SerializeField] private float hoverHeight;
    [SerializeField] private float raycastLength;
    [SerializeField] private float strength;
    [SerializeField] private float dampening;
    [SerializeField] private Rigidbody body;
    private float lastHitDistance;

    void Start()
    {
        lastHitDistance = raycastLength;
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(body.position, -Vector3.up, out hit, raycastLength))
        {
            float forceAmount = CalculateForce(hit.distance);
            //body.AddForceAtPosition(Vector3.up * forceAmount, body.position, ForceMode.Force);
            body.position += new Vector3(0,forceAmount * Time.fixedDeltaTime,0);
        }
        else
        {
            lastHitDistance = raycastLength * 1.1f;
        }
    }

    private float CalculateForce(float distance)
    {
        float forcePower = strength * (raycastLength - distance) + dampening * (lastHitDistance - distance);
        forcePower = Mathf.Max(0, forcePower);
        lastHitDistance = distance;
        return forcePower;
    }
}
