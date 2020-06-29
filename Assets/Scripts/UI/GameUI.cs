using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    Canvas gameOverCanvas;

    //private void Awake()
    //{
    //    int numGameUI = FindObjectsOfType<GameUI>().Length;
    //    if (numGameUI > 1)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        DontDestroyOnLoad(gameObject);
    //    }
    //}

    public Canvas GetGameOverCanvas()
    {
        return gameOverCanvas;
    }
}
