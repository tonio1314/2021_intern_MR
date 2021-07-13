using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void Goto(string SceneName)
    {
        SceneManager.LoadScene(SceneName);//讀取場景,場景名稱

    }

}
