using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreenScene");
    }

    public void CreditsScreen()
    {
        SceneManager.LoadScene("CreditScene");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("InstructionScene");
    }
}
