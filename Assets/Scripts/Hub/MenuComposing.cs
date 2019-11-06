using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuComposing : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] public GameObject fridge;
    public static bool gameIsPaused= false;
    private bool canOpenMenu = false;

    public List<GameObject> fridgeContent;

    //Dish costs in ingredient
    public int onionCost;
    public int lemonCost;
    public int eggplantCost;
    public int watermelonCost;



    void Start()
    {
        menu.SetActive(false);
        fridgeContent = fridge.GetComponent<FridgeContent>().loot;
    }

    // Update is called once per frame
    void Update()
    {
        if(canOpenMenu)
        {
            if (Input.GetButtonDown("Pick"))
            {
                if (gameIsPaused)
                {
                    Resume();
                    Debug.Log("Resume");
                }
                else
                {
                    Pause();
                    Debug.Log("Pause");
                }
            }
        }
        
    }

    void CreateMenu()
    {
        //Choose Entry
        //Choose MainCourse
        //Choose Desert
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canOpenMenu = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canOpenMenu = false;
        menu.SetActive(false);
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }


    //List of every dish

    public void Entry_1()
    {
        Debug.Log("Entry_One");
    }

    public void Entry_2()
    {
        Debug.Log("Entry_Two");
    }
    public void Entry_3()
    {
        Debug.Log("Entry_Three");
    }
    public void MainCourse_1()
    {
        Debug.Log("MainCourse_One");
    }
    public void MainCourse_2()
    {
        Debug.Log("MainCourse_Two");
    }
    public void MainCourse_3()
    {
        Debug.Log("MainCourse_Three");
    }
    public void Desert_1()
    {
        Debug.Log("Desert_One");
    }
    public void Desert_2()
    {
        Debug.Log("Desert_Two");
    }
    public void Desert_3()
    {
        Debug.Log("Desert_Three");
    }

    public void EraseMenu()
    {
        onionCost = 0;
        lemonCost = 0;
        eggplantCost = 0;
        watermelonCost = 0;
        
    }




}
