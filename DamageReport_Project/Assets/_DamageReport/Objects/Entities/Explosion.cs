using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] PrefabSpawner prefabSpawner;
    [SerializeField] AreaDamageDealer damageDealer;
    [SerializeField] Death death;
    private IEnumerator Start()
    {
        yield return new WaitForFixedUpdate();
        damageDealer.Deal();
        prefabSpawner.Spawn();
        death.Die();
    }
}
