using UnityEngine;

public class ShootAtTarget : MonoBehaviour
{
    [SerializeField] private TargetSelector targetSelector;
    [SerializeField] private Rigidbody projectile;
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
        var target = targetSelector.GetTarget();
        if (target == null)
        {
            return;
        }
        var direction = (target.position - transform.position).normalized;
        var spawnPosition = transform.position + impulse / projectile.mass * elapsedTime * direction;
        var newProjectile = Instantiate(projectile, spawnPosition, Quaternion.identity);
        newProjectile.AddForce(impulse * direction, ForceMode.Impulse);
    }
}
