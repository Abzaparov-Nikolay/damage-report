using UnityEngine;

public class ManualTarget : TargetSelector
{
    [SerializeField] private Transform target;

    public override bool TryGetTarget(out Transform target) => target = this.target;
}
