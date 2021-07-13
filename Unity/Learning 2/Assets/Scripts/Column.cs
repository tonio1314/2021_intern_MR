using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Globalization;
using System.Threading;

[RequireComponent(typeof(MeshFilter))]
public class Column : MonoBehaviour
{

    Vector3[] newVertices;
    int[] newTriangles;
    float time = 1;
    int h = 0;

    float bc = 1;
    float sec = 1;
    float l = 1;
    float br = 1;
    int q = 1;


    public AudioClip OpenDoorSound;  
    private AudioSource source;


    void Start()
    {
        bc = staticvariable.colcondition;
        sec = staticvariable.colsection;
        l = staticvariable.collength;
        br = staticvariable.colbracing;
        
        source = GetComponent<AudioSource>(); 

        // Connectivity
        StreamReader sr = new StreamReader(@"/Users/tonylee/Desktop/Column" + @"/BC"+bc+@"/Sec"+sec+@"/L"+l+@"/BR"+br+@"/Connectivity.txt", Encoding.Default);
        string s1 = sr.ReadLine();
        string[] s2 = new string[4];
        int number = 3335;
        newTriangles = new int[number * 6];

        int i = 0;
        while (s1 != null)
        {
            s2 = s1.Split(',');

            newTriangles[6 * i] = Convert.ToInt32(s2[0]) - 1;
            newTriangles[6 * i + 1] = Convert.ToInt32(s2[1]) - 1;
            newTriangles[6 * i + 2] = Convert.ToInt32(s2[2]) - 1;
            newTriangles[6 * i + 3] = Convert.ToInt32(s2[0]) - 1;
            newTriangles[6 * i + 4] = Convert.ToInt32(s2[2]) - 1;
            newTriangles[6 * i + 5] = Convert.ToInt32(s2[3]) - 1;

            i++;
            s1 = sr.ReadLine();
        }
        sr.Close();

        // 1~201 Column?
        StreamReader srr = new StreamReader(@"/Users/tonylee/Desktop/Column" + @"/BC"+bc+@"/Sec"+sec+@"/L"+l+@"/BR"+br+@"/1.txt", Encoding.Default);
        string s3 = srr.ReadLine();
        string[] s4 = new string[3];
        newVertices = new Vector3[3335*3];

        int k = 0;
        while (s3 != null)
        {
            s4 = s3.Split(',');
            float a = float.Parse(s4[0]);
            float b = float.Parse(s4[1]);
            float c = float.Parse(s4[2]);

            //CultureInfo providers = new CultureInfo("en-US");
            //NumberStyles styles = NumberStyles.Float;
            //float a = Single.Parse(s4[0], styles, providers);
            //float b = Single.Parse(s4[1], styles, providers);
            //float c = Single.Parse(s4[2], styles, providers);

            newVertices[k] = new Vector3(a, c, b);

            k++;
            s3 = srr.ReadLine();
        }
        srr.Close();


        // Mesh them
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;
    }



    // 按按鍵改變形狀
    void Update()
    {

        bc = staticvariable.colcondition;
        sec = staticvariable.colsection;
        l = staticvariable.collength;
        br = staticvariable.colbracing;

        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            h = h + 1;
            //source.PlayOneShot(OpenDoorSound, 1F);
            //source.volume = 0.1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            h = h - 1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            h = 0;
            source.volume = 0;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            h = 0;
        }

        time = time + Time.deltaTime * h;

        q = Convert.ToInt32(time);

        staticvariable.step = q;


        if (time >= 200)
        {
            time = 200;
            h = 0;
        }

        StreamReader srr = new StreamReader(@"/Users/tonylee/Desktop/Column" + @"/BC" + bc + @"/Sec" + sec + @"/L" + l +@"/BR"+br+ @"/"+ q + @".txt", Encoding.Default);
        string s3 = srr.ReadLine();
        string[] s4 = new string[3];
        vertices = new Vector3[3335*3];
        int k = 0;


        while (s3 != null)
        {
            s4 = s3.Split(',');

            float a = float.Parse(s4[0]);
            float b = float.Parse(s4[1]);
            float c = float.Parse(s4[2]);

            //CultureInfo providers = new CultureInfo("en-US");
            //NumberStyles styles = NumberStyles.Float;
            //float a = Single.Parse(s4[0], styles, providers);
            //float b = Single.Parse(s4[1], styles, providers);
            //float c = Single.Parse(s4[2], styles, providers);

            vertices[k] = new Vector3(a, c, b);

            k++;
            s3 = srr.ReadLine();
        }
        srr.Close();
        
     /*   Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++){
            colors[i] = Color.Lerp(Color.red, Color.green, vertices[i].y);
        }
*/

        
        mesh.vertices = vertices;
        //mesh.colors = colors;
    }




}