using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootAtTarget : MonoBehaviour
{
    [SerializeField] private TargetSelector targetSelector;
    [SerializeField] private PooledObjectSource projectileSource;
    [SerializeField] private List<Transform> projectileSpawnPoints;
    [SerializeField] private Reference<float> impulse;
    [SerializeField] private Reference<float> fireRate;
    [SerializeField] private Reference<float> fireRateMultiplier;
    [SerializeField] private List<UnityEvent> fireEvents;
    [SerializeField] private UnityEvent<float> fireRateChangedEvent;
    private int currentShootPoint = 0;
    private float timeSinceLastShot;

    private void FixedUpdate()
    {
        var totalFireInterval = 1 / (fireRate * fireRateMultiplier);
        fireRateChangedEvent?.Invoke(fireRate * fireRateMultiplier);
        timeSinceLastShot += Time.fixedDeltaTime;
        while (timeSinceLastShot > totalFireInterval)
        {
            timeSinceLastShot -= totalFireInterval;
            Shoot(timeSinceLastShot);
        }
    }

    private void Shoot(float elapsedTime)
    {
        if (!targetSelector.TryGetTarget(out var target))
        {
            return;
        }
        var spawnPoint = projectileSpawnPoints[currentShootPoint];
        var direction = (target.position - spawnPoint.position).normalized;
        var newProjectile = projectileSource.Get();
        var body = newProjectile.GetComponent<Rigidbody>();
        var spawnPosition = spawnPoint.position + impulse / body.mass * elapsedTime * direction;
        newProjectile.transform.position = spawnPosition;
        newProjectile.transform.rotation = spawnPoint.rotation;
        body.AddForce(impulse * direction, ForceMode.Impulse);
        if (fireEvents.Count > 0)
            fireEvents[currentShootPoint]?.Invoke();
        currentShootPoint++;
        if (currentShootPoint >= projectileSpawnPoints.Count)
        {
            currentShootPoint = 0;
        }
    }
}
