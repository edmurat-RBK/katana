using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    public GameObject firstSelectedObject;
    public AudioSource source;
    public AudioClip selectedClip;
    public AudioClip pressedClip;
    public EventSystem eventSystem;
    public GameObject controlPanel;
    private bool isInOptions = false;


    void Start()
    {
        eventSystem = EventSystem.current;
        
    }
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

       if(isInOptions && Input.GetButtonDown("MeleeAttack"))
       {
            controlPanel.SetActive(false);
            isInOptions = false;
       }
    }

    public void Resume()
    {
        controlPanel.SetActive(false);
        isInOptions = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().SoundCutoffOff();
    }
    
    private void Pause()
    {

        pauseMenu.SetActive(true);
        eventSystem.GetComponent<EventSystem>().firstSelectedGameObject = firstSelectedObject;
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstSelectedObject);
        Time.timeScale = 0f;
        gameIsPaused = true;
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().SoundCutoffOn();
    }

    public void onQuit()
    {
        Time.timeScale = 1f;
        gameIsPaused = false;
        SceneManager.LoadScene("TitleScreen");
    }

    public void onOptions()
    {
        controlPanel.SetActive(true);
        isInOptions = true;
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
