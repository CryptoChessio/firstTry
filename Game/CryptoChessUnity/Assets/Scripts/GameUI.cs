using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public static GameUI instance { set; get; }

    private void Awake()
    {
        instance = this;
    }

    // buttons 

    public void OnStartGame()
    {
        Debug.Log("New Game");
    }

    public void OnBack()
    {
        Debug.Log("Back");
    }
}
