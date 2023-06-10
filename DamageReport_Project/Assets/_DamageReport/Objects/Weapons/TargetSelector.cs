using UnityEngine;

public abstract class TargetSelector : MonoBehaviour
{
    public abstract bool TryGetTarget(out Transform target);
}
