using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blinking : MonoBehaviour
{
    [SerializeField] private float interval;
    [SerializeField] private float duration;
    [SerializeField] private Color blinkingColor;
     private bool isBlinking;

    [ContextMenu("Start")]
    public void StartBlinking()
    {
        var renderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        if(isBlinking)
            return;
        else
            isBlinking = true;
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
            renderer.material.color = blinkingColor;
            yield return new WaitForSeconds(interval/2);
            renderer.material.color = startColor;
            yield return new WaitForSeconds(interval/2);
        }
        isBlinking = false;
    }
}
