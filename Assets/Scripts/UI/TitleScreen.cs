using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void OnNewGame()
    {
        SceneManager.LoadScene("SandboxScene");
    }

    public void OnOptions()
    {
        Debug.Log("Option LV3");
    }

    public void OnCredits()
    {
        Debug.Log("Crédits : La meilleure team");
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
