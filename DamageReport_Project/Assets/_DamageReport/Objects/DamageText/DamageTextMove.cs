using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextMove : MonoBehaviour
{
    [SerializeField] public Vector3 velocity;

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
