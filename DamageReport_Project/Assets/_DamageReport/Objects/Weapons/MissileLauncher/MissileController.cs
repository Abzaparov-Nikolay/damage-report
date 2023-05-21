using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private Rigidbody body;
    [SerializeField] private new ParticleSystem particleSystem;
    [SerializeField] private float force;
    [SerializeField] private float turnSpeed;
    [SerializeField] private bool useForce;
    [SerializeField] private float acceleration;
    [SerializeField] private float topSpeed;
    private bool motorOn = false;
    private float speed = 0;
    private Quaternion startRotation;
    private float rotationTime;
    private bool detachParticleSystem = true;
    private void Start()
    {
        startRotation = transform.rotation;
        rotationTime = 0;
    }

    private void Update()
    {
        if (target == null)
        {
            GetComponent<Death>().Die();
            detachParticleSystem = false;
            return;
        }
        if (motorOn)
        {
            speed += acceleration * Time.deltaTime;
            if (speed >= topSpeed)
                speed = topSpeed;
        }
        else
        {
            var direction = target.transform.position - body.position;
            direction.Normalize();
            transform.rotation = Quaternion.Lerp(startRotation, Quaternion.LookRotation(direction, Vector3.up), rotationTime);
            if (rotationTime >= 1)
            {
                rotationTime = 1;
            }
            else
            {
                rotationTime += Time.deltaTime * turnSpeed;
            }
        }
    }
    private void FixedUpdate()
    {
        if (target == null)
        {
            GetComponent<Death>().Die();
            detachParticleSystem = false;
            return;
        }
        if (motorOn)
        {
            var direction = target.transform.position - body.position;
            direction.Normalize();
            if (useForce)
                body.AddForce(force * direction, ForceMode.Force);
            else
                body.position += speed * direction * Time.fixedDeltaTime;
            transform.LookAt(target.transform);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.fixedDeltaTime);
        }
    }

    public void StartMotor()
    {
        motorOn = true;
        particleSystem.Play();
    }

    public void OnDeath()
    {
        if (detachParticleSystem)
        {
            particleSystem.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            particleSystem.gameObject.transform.parent = null;
            particleSystem.gameObject.GetComponent<Timer>().Restart();
        }
    }
}
