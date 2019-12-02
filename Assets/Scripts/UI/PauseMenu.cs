using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public AudioSource source;
    public AudioClip selectedClip;
    public AudioClip pressedClip;


    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Pause"))
       {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
       }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().SoundCutoffOff();
    }
    
    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().SoundCutoffOn();
    }

    public void onQuit()
    {
        Debug.Log("QUIT WIP");
    }

    public void onOptions()
    {
        Debug.Log("OPTIONS WIP");
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
