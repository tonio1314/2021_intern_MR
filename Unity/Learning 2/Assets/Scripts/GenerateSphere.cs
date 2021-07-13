using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSphere : MonoBehaviour
{
    public float speed = 500;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.down * Time.deltaTime * speed);
    }

    public void ChangeSpeed(float NewSpeed)
    {
        this.speed = NewSpeed;
    }
}
