using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolMember : PoolMember
{
    [SerializeField] Rigidbody body;
    public override void DeInitialize()
    {
        body.velocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
    }

    public override void Initialize()
    {
    }
}
