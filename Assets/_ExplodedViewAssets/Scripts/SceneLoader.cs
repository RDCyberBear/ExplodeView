using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadViewport()
    {
        SceneManager.LoadScene("ExlodedView");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
