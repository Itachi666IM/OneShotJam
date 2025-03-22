using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject cutScene;
    public GameObject story;
    public GameObject storyPanel;
    public void Play()
    {
        story.SetActive(true);
        storyPanel.SetActive(true);
    }

    public void StartCutScene()
    {
        cutScene.SetActive(true);
    }
    public void Exit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }
}
