using UnityEngine;

public class RotateGunAtTarget : MonoBehaviour
{
    [SerializeField] private TargetSelector targetSelector;
    [SerializeField] private Transform gunBase;
    [SerializeField] private Transform barrel;

    private void FixedUpdate()
    {
        if (!targetSelector.TryGetTarget(out var target))
        {
            return;
        }

        var direction = target.position - transform.position;
        var horizontalDirection = direction.Xz();
        gunBase.rotation = Quaternion.Euler(0, 90 - horizontalDirection.Angle(), 0);

        var verticalAngle = Mathf.Atan2(direction.y, horizontalDirection.magnitude) * Mathf.Rad2Deg;
        barrel.rotation = Quaternion.Euler(-verticalAngle, barrel.rotation.eulerAngles.y, barrel.rotation.eulerAngles.z);
    }
}
