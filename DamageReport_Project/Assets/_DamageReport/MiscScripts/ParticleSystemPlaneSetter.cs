using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemPlaneSetter : MonoBehaviour
{
    [SerializeField] new ParticleSystem particleSystem;
    [SerializeField] List<Reference<Transform>> planes;

    private void Awake()
    {
        foreach(var plane in planes)
        {
            particleSystem.collision.AddPlane(plane);
        }
    }
}
