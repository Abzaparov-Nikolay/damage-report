using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextMoveAndFade : MonoBehaviour
{
    [SerializeField] public Vector3 velocity;
    [SerializeField] private float fadeSpeed;
    private TextMeshPro text;
    private Color textColor;
    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        textColor = text.color;
    }
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        textColor.a -= fadeSpeed * Time.deltaTime;
        text.color = textColor;
    }
}
