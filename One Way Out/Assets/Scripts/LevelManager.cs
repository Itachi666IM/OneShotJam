using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject levelPanel;
    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        int instance = FindObjectsOfType<LevelManager>().Length;
        if(instance > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            levelPanel.SetActive(true);
        }    
    }

    public void Resume()
    {
        levelPanel.SetActive(false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        levelPanel.SetActive(false);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene("Level 1");
        levelPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
