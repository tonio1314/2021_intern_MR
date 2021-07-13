using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundChange : MonoBehaviour
{
    public GameObject SoundButton;
    public bool isSoundOn = true;


    // Use this for initialization
    void Start()
    {
        SoundButton = GameObject.Find("Canvas/SoundButton");
    }

    // Update is called once per frame
    void Update()
    {
        SoundButton = GameObject.Find("Canvas/SoundButton");
    }
    public void SoundButtonPress()
    {
        if (isSoundOn)
        {
            Button mButton = SoundButton.GetComponent<Button>();    
            mButton.image.sprite = Resources.Load<Sprite>("SoundOff");
            isSoundOn = false;

        }
        else
        {
            Button mButton = SoundButton.GetComponent<Button>();
            mButton.image.sprite = Resources.Load<Sprite>("SoundOn");
            isSoundOn = true;
        }

    }

}
