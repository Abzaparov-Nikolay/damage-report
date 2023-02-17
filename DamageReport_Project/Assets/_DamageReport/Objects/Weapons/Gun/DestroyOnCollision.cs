using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    [SerializeField] private int collisionsBeforeDestroy;
    private int currentCollisionCount;

    private void OnCollisionEnter(Collision other)
    {
        currentCollisionCount++;
        if(currentCollisionCount >= collisionsBeforeDestroy)
        {
            Destroy(gameObject);
        }
    }
}
