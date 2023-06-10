using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PositionConstraintSetter : MonoBehaviour
{
    [SerializeField] private PositionConstraint positionConstraint;
    [SerializeField] private Reference<Transform> source;
    private void OnEnable()
    {
        Set();
        source.OnChanged += Set;
    }

    public void Set()
    {
        if (source.Value != null)
        {
            var constraintSource = new ConstraintSource();
            constraintSource.sourceTransform = source.Value;
            constraintSource.weight = 1;
            positionConstraint.AddSource(constraintSource);
        }
    }
}
