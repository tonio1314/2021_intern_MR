using System.Collections.Generic;
using UnityEngine;
public class GenerateCir : MonoBehaviour
{
    public int circle, radius;
    List<Vector3> vertices = new List<Vector3>();
    List<int> triangles = new List<int>();

    private void Start()
    {
        for (int i = 0; i < circle; i++)
        {
            float y = radius * Mathf.Sin(Mathf.Deg2Rad * (360 / ((float)circle) * i)); // Mathf.Deg2Rad = 2*pi/360, it is a const.
            float x = radius * Mathf.Cos(Mathf.Deg2Rad * (360 / ((float)circle) * i));
            vertices.Add(new Vector3(x, y, 0));
        }
        for (int l = 0; l < circle; l++)
        {
            this.triangles.AddRange(new List<int>() { vertices.Count, vertices.Count + 1, vertices.Count + 2 });
            vertices.AddRange(new List<Vector3>() { vertices[l], vertices[l + 1], Vector3.zero });
        }
        Mesh mesh = new Mesh();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        GetComponent<MeshFilter>().mesh = mesh;
        //gameObject.transform.localPosition = new Vector3(904, 470, 0);
    }
}