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
    public GameObject controlPanel;
    private bool isInOptions = false;

    public void OnNewGame()
    {
        SceneManager.LoadScene("HubScene");
    }

    void Update()
    {
        if (isInOptions && Input.GetButtonDown("MeleeAttack") )
        {
            controlPanel.SetActive(false);
            isInOptions = false;
        }
    }
    public void OnOptions()
    {
        controlPanel.SetActive(true);
        isInOptions = true;
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
