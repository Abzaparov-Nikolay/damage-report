using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolMember : MonoBehaviour
{
    public abstract void Initialize();
    public abstract void DeInitialize();
}
