using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    [SerializeField] private float interval;
    [SerializeField] private float duration;
    [SerializeField] private Color color;

    [ContextMenu("Start")]
    public void StartBlinking()
    {
        var renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach(var renderer in renderers)
        {
            StartCoroutine(Blink(renderer));
        }
    }

    private IEnumerator Blink(Renderer renderer)
    {
        var startColor = renderer.material.color;
        for (var i = 0; i < duration / interval; i++)
        {
            renderer.material.color = color;
            yield return new WaitForSeconds(interval/2);
            renderer.material.color = startColor;
            yield return new WaitForSeconds(interval/2);
        }
    }
}
