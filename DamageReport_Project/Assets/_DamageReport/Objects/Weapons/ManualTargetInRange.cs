using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualTargetInRange : TargetSelector
{
    private enum Mode
    {
        ThreeDimensional,
        HorizontalOnly
    }
    [SerializeField] private Variable<Transform> target;
    [SerializeField] private float range;
    [SerializeField] private Mode mode;


    public override bool TryGetTarget(out Transform target)
    {
        if (!this.target)
        {
            target = null;
            return false;
        }
        target = this.target;
        switch(mode)
        {
            case Mode.ThreeDimensional:
                var distanceToTarget3D = (this.target.Get().position - transform.position).magnitude;
                return distanceToTarget3D <= range;
            case Mode.HorizontalOnly:
                var distanceToTarget2D = (this.target.Get().position.Xz() - transform.position.Xz()).magnitude;
                return distanceToTarget2D <= range;
            default:
                return false;
        }
    }
}
