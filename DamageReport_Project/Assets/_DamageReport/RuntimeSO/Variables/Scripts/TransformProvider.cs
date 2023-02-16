using UnityEngine;

public class TransformProvider : MonoBehaviour
{
    [Header(Headers.Output)]
    [SerializeField] private Variable<Transform> transformVariable;

    private void Awake()
    {
        transformVariable.Set(transform);
    }
}
