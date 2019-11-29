using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeUI : MonoBehaviour
{
    public GameObject fridgeUI; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Resume();           
        }
    }

    public void Resume()
    {
        fridgeUI.SetActive(false);
        Time.timeScale = 1f;
    }

}
