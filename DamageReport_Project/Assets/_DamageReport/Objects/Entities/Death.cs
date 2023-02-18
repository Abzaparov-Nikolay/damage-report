using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Death : MonoBehaviour
{
    [SerializeField] private bool DestroyOnDeath = true;
    public UnityEvent OnDeath;

    public void Die()
    {
        OnDeath?.Invoke();
        if(DestroyOnDeath)
        {
            Destroy(gameObject);
        }
    }
}
