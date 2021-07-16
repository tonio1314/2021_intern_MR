using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowBounce : MonoBehaviour
{
    //public GameObject Window;
    //public bool isActive = true;

    private void Start()
    {
        transform.localScale = Vector2.zero;
    }


    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.1f);
    }

    public void Close()
    {
        transform.LeanScale(Vector2.zero, 0.5f).setEaseInBack();
    }


    
    //public void Click()
    //{
    //    if(Window != null && isActive)
    //    {
    //        transform.LeanScale(Vector2.one, 0.2f);
    //        isActive = false;
    //    }

    //    else
    //    {
    //        transform.LeanScale(Vector2.zero, 0.5f).setEaseInBack();
    //        isActive = true;
    //    }
    //}


}
