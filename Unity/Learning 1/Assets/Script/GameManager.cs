using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void OnStartGame(string SceneName)
    {
        Application.LoadLevel(SceneName);//讀取場景,場景名稱

    }

}
