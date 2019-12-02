using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeUI : MonoBehaviour
{
    public GameObject fridgeUI;
    private bool gameIsPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused && Input.GetButtonDown("Attack"))
        {
            Resume();           
        }
    }

    public void Resume()
    {
        fridgeUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Pause()
    {
        fridgeUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

}
