using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CircularElement : MonoBehaviour
{

    private MeshFilter mesh; /*!<  */
    /*!< Raio do circulo (Padrão 0.5f) */
    public float circularRadius = 0.5f;
    [Range(0, 360)]
    /*!< Angulo do mesh a ser gerado */
    public float angleSize = 360f;
    public int numOfPoints;

    public Shader myShader;

    private void Awake()
    {
        mesh = GetComponent<MeshFilter>();

    }

    // Use this for initialization
    void Start()
    {
        mesh.mesh = MakeCircle(numOfPoints);
        MeshConfig();
    }

    private void MeshConfig()
    {
        CircleCollider2D circle = GetComponent<CircleCollider2D>();
        circle.radius = circularRadius;
        circle.isTrigger = true;
        mesh.mesh.RecalculateNormals();
    }

    /*
      Generates a circular mesh
        \param numOfPoints Number of points to generate the vertices.
        \return Mesh with vertices and triangles created.
    */
    public Mesh MakeCircle(int numOfPoints)
    {
        float angleStep = angleSize / (float)numOfPoints;
        List<Vector3> vertexList = new List<Vector3>();
        List<int> triangleList = new List<int>();
        Quaternion quaternion = Quaternion.Euler(0.0f, 0.0f, angleStep);
        // Make first triangle.
        vertexList.Add(new Vector3(0.0f, 0.0f, 0.0f));  // 1. Circle center.
        vertexList.Add(new Vector3(0.0f, circularRadius, 0.0f));  // 2. First vertex on circle outline (radius = 0.5f)
        vertexList.Add(quaternion * vertexList[1]);     // 3. First vertex on circle outline rotated by angle)
                                                        // Add triangle indices.
        triangleList.Add(0);
        triangleList.Add(1);
        triangleList.Add(2);

        for (int i = 0; i < numOfPoints - 1; i++)
        {
            triangleList.Add(0);                      // Index of circle center.
            triangleList.Add(vertexList.Count - 1);
            triangleList.Add(vertexList.Count);
            vertexList.Add(quaternion * vertexList[vertexList.Count - 1]);
        }

        Mesh _mesh = new Mesh();
        _mesh.name = "Circular";
        _mesh.vertices = vertexList.ToArray();
        _mesh.triangles = triangleList.ToArray();
        return _mesh;
    }

    /*
      Create a circular mesh
      param material Material para ser aplicado ao objeto.
    */

    public void SetMaterial(Material material)
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material = material;
    }
}
