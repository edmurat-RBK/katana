using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    //Audio
    public AudioSource source;
    public AudioClip selectedClip;
    public AudioClip pressedClip;

    public void OnNewGame()
    {
        SceneManager.LoadScene("HubScene");
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

    public void SelectedSound()
    {
        source.clip = selectedClip;
        source.Play();
    }

    public void PressedSound()
    {
        source.clip = pressedClip;
        source.Play();
    }
}
