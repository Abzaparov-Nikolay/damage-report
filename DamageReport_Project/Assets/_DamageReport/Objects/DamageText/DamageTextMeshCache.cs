using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTextMeshCache : MonoBehaviour
{
    private class MeshAndTime
    {
        public Mesh mesh;
        public float time;
        public MeshAndTime(Mesh mesh)
        {
            this.mesh = mesh;
            time = 0;
        }
    }
    [SerializeField] private float storageTime;
    [SerializeField] private TextMeshPro tmp;
    private Dictionary<float, MeshAndTime> meshes = new Dictionary<float, MeshAndTime>();
    public Mesh GetMesh(float num)
    {
        if (meshes.TryGetValue(num, out var mesh))
        {
            return mesh.mesh;
        }
        else
        {
            tmp.text = num.ToString();
            meshes.Add(num, new MeshAndTime(tmp.mesh));
            return tmp.mesh;
        }
    }

    private void Update()
    {
        var pairsToRemove = new List<float>();
        foreach (var keyValue in meshes)
        {
            keyValue.Value.time += Time.deltaTime;
            if (keyValue.Value.time >= storageTime)
            {
                pairsToRemove.Add(keyValue.Key);
            }
        }
        foreach (var key in pairsToRemove)
        {
            meshes.Remove(key);
        }
    }
}
