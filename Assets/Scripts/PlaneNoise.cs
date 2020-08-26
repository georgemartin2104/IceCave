using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneNoise : MonoBehaviour
{
    public float power = 3.0f;
    public float scale = 1.0f;
    private Vector2 wallPlane = new Vector2(0f, 0f);

    void Start()
    {
        wallPlane = new Vector2(Random.Range(0.0f, 100.0f), Random.Range(0.0f, 100.0f));
        generate();
    }

    void generate()
    {
        MeshFilter planeMesh = GetComponent<MeshFilter>();
        Vector3[] vertices = planeMesh.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            float xCoord = wallPlane.x + vertices[i].x * scale;
            float yCoord = wallPlane.y + vertices[i].z * scale;
            vertices[i].y = (Mathf.PerlinNoise(xCoord, yCoord) - 0.5f) * power;
        }
        planeMesh.mesh.vertices = vertices;
        planeMesh.mesh.RecalculateBounds();
        planeMesh.mesh.RecalculateNormals();
    }
}
