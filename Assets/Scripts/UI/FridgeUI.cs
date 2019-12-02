using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeUI : MonoBehaviour
{
    public GameObject fridgeUI;
    private bool gameIsPaused = false;
    private GameManager gameManager;

    public int onionCount = 0;
    public int watermelonCount = 0;
    public int lemonCount = 0;
    public int eggplantCount = 0;
    public int tofuCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused && Input.GetButtonDown("MeleeAttack"))
        {
            Resume();           
        }

        
    }

    public void Resume()
    {
        fridgeUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
        ResetCount();
    }

    public void Pause()
    {
        UpdateCount();
        fridgeUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Debug.Log(onionCount);
        Debug.Log(watermelonCount);
        Debug.Log(lemonCount);
        Debug.Log(eggplantCount);
        Debug.Log(tofuCount);
    }

    private void UpdateCount()
    {
        for(int i = 0; i < gameManager.fridgeInventory.Count; i++)
        {
            switch(gameManager.fridgeInventory[i])
            {
                case Item.ONION:
                    onionCount++;
                    break;

                case Item.WATERMELON:
                    watermelonCount++;
                    break;

                case Item.LEMON:
                    lemonCount++;
                    break;

                case Item.EGGPLANT:
                    eggplantCount++;
                    break;

                case Item.TOFU:
                    tofuCount++;
                    break;

                default: break;        
            }
        }
    }

    private void ResetCount()
    {
        onionCount = 0;
        watermelonCount = 0;
        lemonCount = 0;
        eggplantCount = 0;
        tofuCount = 0;
    }

}
