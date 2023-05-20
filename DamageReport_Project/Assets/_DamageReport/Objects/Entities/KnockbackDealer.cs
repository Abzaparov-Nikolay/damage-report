using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackDealer : MonoBehaviour
{
    [SerializeField] private Reference<float> impulse;

    public void Deal(GameObject target)
    {
        if (target.TryGetComponent<Rigidbody>(out var otherBody))
        {
            var impulseVector = (otherBody.transform.position - transform.position).normalized * impulse;
            otherBody.AddForce(impulseVector, ForceMode.Impulse);
        }
    }
}
