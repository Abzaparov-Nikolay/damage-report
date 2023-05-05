using UnityEngine;

public class RuntimeSetMember : MonoBehaviour
{
    [SerializeField] private RuntimeSet<GameObject> set;

    private void OnEnable()
    {
        set.Add(gameObject);
    }

    private void OnDisable()
    {
        set.Remove(gameObject);
    }
}
