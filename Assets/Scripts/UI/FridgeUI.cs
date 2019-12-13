using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //Text
    public GameObject eggplantNumber;
    public GameObject onionNumber;
    public GameObject lemonNumber;
    public GameObject watermelonNumber;
    public GameObject tofuNumber;


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

        eggplantNumber.GetComponent<Text>().text = eggplantCount.ToString() ;
        onionNumber.GetComponent<Text>().text = onionCount.ToString();
        lemonNumber.GetComponent<Text>().text = lemonCount.ToString();
        watermelonNumber.GetComponent<Text>().text = watermelonCount.ToString();
        tofuNumber.GetComponent<Text>().text = tofuCount.ToString();

        if(eggplantCount<=0)
        {
            eggplantNumber.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            eggplantNumber.transform.parent.gameObject.SetActive(true);
        }

        if(onionCount<=0)
        {
            onionNumber.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            onionNumber.transform.parent.gameObject.SetActive(true);
        }

        if(lemonCount<=0)
        {
            lemonNumber.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            lemonNumber.transform.parent.gameObject.SetActive(true);
        }

        if(watermelonCount<=0)
        {
            watermelonNumber.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            watermelonNumber.transform.parent.gameObject.SetActive(true);
        }

        if(tofuCount<=0)
        {
            tofuNumber.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            tofuNumber.transform.parent.gameObject.SetActive(true);
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
