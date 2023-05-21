using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileLauncherController : MonoBehaviour
{
    [SerializeField] private Reference<float> fireRate;
    [SerializeField] private float launchImpulse;
    [SerializeField] private TargetSelector targetSelector;
    [SerializeField] private GameObject missileSpawnPoint;
    [SerializeField] private GameObject missilePrefab;
    private float cooldownTimeLeft = 0;

    void Update()
    {
        if (cooldownTimeLeft <= 0)
        {
            if (targetSelector.TryGetTarget(out var target)) {
                cooldownTimeLeft = 1 / fireRate;
                Launch(target);
            }
        }
        else
        {
            cooldownTimeLeft -= Time.deltaTime;
        }
    }

    private void Launch(Transform target)
    {
        var missile = Instantiate(missilePrefab, missileSpawnPoint.transform.position, Quaternion.identity);
        missile.transform.LookAt(missileSpawnPoint.transform.position + new Vector3(0, 10, 0));
        missile.GetComponent<Rigidbody>().velocity = GetComponentInParent<Rigidbody>().velocity;
        missile.GetComponent<Rigidbody>().AddForce(Vector3.up * launchImpulse, ForceMode.Impulse);
        missile.GetComponent<MissileController>().target = target.gameObject;
    }
}
