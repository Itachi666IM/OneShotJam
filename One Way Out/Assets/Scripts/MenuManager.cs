using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject cutScene;
    public void Play()
    {
        cutScene.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
