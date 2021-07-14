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

    float boundarycondition = 1;
    float section = 1;
    float length = 1; // l 不確定是不是length
    float bracing = 1;
    int index = 1;


    public AudioClip OpenDoorSound;  
    private AudioSource source;


    void Start()
    {
        boundarycondition = staticvariable.colcondition;
        section = staticvariable.colsection;
        length = staticvariable.collength;
        bracing = staticvariable.colbracing;
        
        source = GetComponent<AudioSource>(); 

        // Connectivity 上下兩端加板，避免應力集中

        StreamReader streamreaderConn =
            new StreamReader (@"/Users/tonylee/Desktop/Column" + @"/BC"+ boundarycondition + @"/Sec"+ section +@"/L"+ length +@"/BR"+ bracing +@"/Connectivity.txt", Encoding.Default);
        string string1 = streamreaderConn.ReadLine();
        string[] string2 = new string[4];
        int number = 3335;
        newTriangles = new int[number * 6];

        int i = 0;
        while (string1 != null)
        {
            string2 = string1.Split(',');

            newTriangles[6 * i] = Convert.ToInt32(string2[0]) - 1;
            newTriangles[6 * i + 1] = Convert.ToInt32(string2[1]) - 1;
            newTriangles[6 * i + 2] = Convert.ToInt32(string2[2]) - 1;
            newTriangles[6 * i + 3] = Convert.ToInt32(string2[0]) - 1;
            newTriangles[6 * i + 4] = Convert.ToInt32(string2[2]) - 1;
            newTriangles[6 * i + 5] = Convert.ToInt32(string2[3]) - 1;

            i++;
            string1 = streamreaderConn.ReadLine();
        }
        streamreaderConn.Close();

        // 1~201 Column?
        StreamReader streamreaderCol =
            new StreamReader(@"/Users/tonylee/Desktop/Column" + @"/BC"+ boundarycondition +@"/Sec"+ section +@"/L"+ length +@"/BR"+ bracing + @"/1.txt", Encoding.Default);
        string string3 = streamreaderCol.ReadLine();
        string[] string4 = new string[3]; 
        newVertices = new Vector3[3335*3];

        int k = 0;
        while (string3 != null)
        {
            string4 = string3.Split(',');

            CultureInfo providers = new CultureInfo("en-US");
            NumberStyles styles = NumberStyles.Float;
            float a = Single.Parse(string4[0], styles, providers);
            float b = Single.Parse(string4[1], styles, providers);
            float c = Single.Parse(string4[2], styles, providers);

            newVertices[k] = new Vector3(a, c, b);
            k++;

            string3 = streamreaderCol.ReadLine();
        }
        streamreaderCol.Close();


        // Mesh them
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = newVertices;
        mesh.triangles = newTriangles;
    }



    // 按按鍵改變形狀
    void Update()
    {

        boundarycondition = staticvariable.colcondition;
        section = staticvariable.colsection;
        length = staticvariable.collength;
        bracing = staticvariable.colbracing;

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

        index = Convert.ToInt32(time);

        staticvariable.step = index;


        if (time >= 200)
        {
            time = 200;
            h = 0;
        }

        StreamReader streamreaderCol =
            new StreamReader(@"/Users/tonylee/Desktop/Column" + @"/BC" + boundarycondition + @"/Sec" + section + @"/L" + length + @"/BR"+ bracing + @"/"+ index + @".txt", Encoding.Default);
        string string3 = streamreaderCol.ReadLine();
        string[] string4 = new string[3];
        vertices = new Vector3[3335*3];
        int k = 0;


        while (string3 != null)
        {
            string4 = string3.Split(',');

            CultureInfo providers = new CultureInfo("en-US");
            NumberStyles styles = NumberStyles.Float;
            float a = Single.Parse(string4[0], styles, providers);
            float b = Single.Parse(string4[1], styles, providers);
            float c = Single.Parse(string4[2], styles, providers);

            vertices[k] = new Vector3(a, c, b);

            k++;
            string3 = streamreaderCol.ReadLine();
        }
        streamreaderCol.Close();
        
    /*  Color[] colors = new Color[vertices.Length];

        for (int i = 0; i < vertices.Length; i++){
            colors[i] = Color.Lerp(Color.red, Color.green, vertices[i].y);
        }
    */
        mesh.vertices = vertices;
        //mesh.colors = colors;
    }

}