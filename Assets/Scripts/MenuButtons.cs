using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{


    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("start screen");
    }

    public void CreditsScreen()
    {
        SceneManager.LoadScene("creadit screan");
    }

}
