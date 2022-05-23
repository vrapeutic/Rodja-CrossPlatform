using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] GameEvent sessionEnds;

    public void BackToMainMenu()
    {
        sessionEnds.Raise();
        Invoke("LoadScene", 2f);
       
    }

    public void ExitGame()
    {
        sessionEnds.Raise();
        Invoke("ExitProject", 2f);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
    public void ExitProject()
    {
        Application.Quit();

    }
}
