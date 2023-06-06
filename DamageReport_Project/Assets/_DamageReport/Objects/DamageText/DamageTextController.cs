using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextController : MonoBehaviour
{
    [SerializeField] public Vector3 velocity;
    [SerializeField] private float fadeSpeed;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private Reference<GameObject> meshCache;
    [NonSerialized] public float number;
    private Color textColor;
    private void Start()
    {
        meshFilter.mesh = meshCache.Get().GetComponent<DamageTextMeshCache>().GetMesh(number);
        //text = GetComponent<TextMeshPro>();
        //textColor = text.color;
    }
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        //textColor.a -= fadeSpeed * Time.deltaTime;
        //var length = meshFilter.mesh.colors32.Length;
        //var newColors = new Color[length];
        //for (var i = 0; i < length; i++)
        //{
        //    newColors[i] = textColor;
        //}
        //meshFilter.mesh.colors = newColors;
    }
}
