using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRect : MonoBehaviour
{
    public Material material;

    void Start()
    {
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] traingles = new int[6]; // 6 = 2*3 2個三角形，三角形頂點有三個

        vertices[0] = new Vector3(0,2);
        vertices[1] = new Vector3(2,2);
        vertices[2] = new Vector3(0,0);
        vertices[3] = new Vector3(2,0);


        traingles[0] = 0;
        traingles[1] = 1;
        traingles[2] = 2;
        traingles[3] = 2;
        traingles[4] = 1;
        traingles[5] = 3;

        uv[0] = new Vector2(0, 2);
        uv[1] = new Vector2(2, 2);
        uv[2] = new Vector2(0, 0);
        uv[3] = new Vector2(2, 0);

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = traingles;

        GameObject gameObject = new GameObject("Rectangle", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localScale = new Vector3(2 , 2 , 1);
        gameObject.transform.localPosition = new Vector3(904 ,470, 0);

        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        gameObject.GetComponent<MeshRenderer>().material = material;
    }

}
