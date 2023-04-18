using UnityEngine;

public class ShootAtTarget : MonoBehaviour
{
    [SerializeField] private TargetSelector targetSelector;
    [SerializeField] private Rigidbody projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Reference<float> impulse;
    [SerializeField] private Reference<float> fireRate;

    private float timeSinceLastShot;

    private void FixedUpdate()
    {
        timeSinceLastShot += Time.fixedDeltaTime;
        while (timeSinceLastShot > 1 / fireRate)
        {
            timeSinceLastShot -= 1 / fireRate;
            Shoot(timeSinceLastShot);
        }
    }

    private void Shoot(float elapsedTime)
    {
        if (!targetSelector.TryGetTarget(out var target))
        {
            return;
        }
        var direction = (target.position - shootPoint.position).normalized;
        var spawnPosition = shootPoint.position + impulse / projectilePrefab.mass * elapsedTime * direction;
        var newProjectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        newProjectile.AddForce(impulse * direction, ForceMode.Impulse);
    }
}
