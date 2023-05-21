using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextSpawner : MonoBehaviour
{
    [SerializeField] private GameObject damageTextPrefab;
    [SerializeField] private Reference<Vector3> positionVariation;
    [SerializeField] private Reference<Vector3> velocityVariation;
    public void Spawn(float damage)
    {
        var pos = transform.position;
        pos += new Vector3( Random.Range(-positionVariation.Get().x, positionVariation.Get().x),
                            Random.Range(-positionVariation.Get().y, positionVariation.Get().y),
                            Random.Range(-positionVariation.Get().z, positionVariation.Get().z));
        var velocity = new Vector3( Random.Range(-velocityVariation.Get().x, velocityVariation.Get().x),
                                    Random.Range(-velocityVariation.Get().y, velocityVariation.Get().y),
                                    Random.Range(-velocityVariation.Get().z, velocityVariation.Get().z));
        var newText = Instantiate(damageTextPrefab, pos, Quaternion.Euler(0, -45, 0));
        newText.GetComponent<TextMeshPro>().text = damage.ToString();
        newText.GetComponent<DamageTextMoveAndFade>().velocity = velocity;
    }
}
