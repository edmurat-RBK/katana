using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;
    public GameObject pauseMenu;

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
    }
    
    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void onQuit()
    {
        Debug.Log("QUIT WIP");
    }

    public void onOptions()
    {
        Debug.Log("OPTIONS WIP");
    }
}
