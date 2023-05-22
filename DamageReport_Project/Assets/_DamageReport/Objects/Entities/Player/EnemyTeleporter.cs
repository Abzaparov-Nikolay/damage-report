using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EnemyTeleporter : MonoBehaviour
{
    [SerializeField] private RuntimeSet<GameObject> enemies;
    [SerializeField, Range(0, 1)] private float distanceRatio;
    [SerializeField] private float boundsSize;
    [SerializeField] private float castStepLength;
    [SerializeField] private int maxCastSteps;

    private static readonly RaycastHit[] raycastResults = new RaycastHit[1];

    private void OnTriggerExit(Collider other)
    {
        if (!enemies.Contains(other.gameObject))
            return;

        var movementToEnemy = (other.transform.position - transform.position).Xz();
        var teleportedPosition = transform.position.Xz() - movementToEnemy * distanceRatio;

        for (var steps = 0; steps < maxCastSteps; steps++)
        {
            var offset = steps * castStepLength * (-1) * movementToEnemy.normalized.AsXz();
            var hits = Physics.BoxCastNonAlloc(
                center: teleportedPosition.AsXz(boundsSize) + offset,
                halfExtents: 0.95f * boundsSize * Vector3.one,
                direction: Vector3.up,
                results: raycastResults,
                orientation: Quaternion.identity,
                maxDistance: 0);

            if (hits == 0)
            {
                other.transform.position = teleportedPosition.AsXz(other.transform.position.y);
                return;
            }
        }
    }
}
