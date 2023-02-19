using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockbackReceiver : MonoBehaviour
{
    public void ReceiveKnockback(Vector3 impulse)
    {
        if(impulse.y<0)
            impulse.y = 0;
        transform.position += impulse;
    }
}
