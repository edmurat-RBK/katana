using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum State
    {
        MENU = 0,
        HUB = 1,
        RUN = 2
    }
    private State gameState = State.MENU;
    public List<Item> fridgeInventory;
    private GameObject hubUI;
    private List<Toggle> toggles = new List<Toggle>();
    private int onionCount = 0;
    private int watermelonCount = 0;
    private int lemonCount = 0;
    private int eggplantCount = 0;
    private int tofuCount = 0;
    public Starters StartersSelect;
    public Plat PlatSelect;
    public Dessert DessertSelect;
    public enum Starters
    {
        None , Starter1 , Starter2 , Starter3
    }
    public enum Plat
    {
        None , Plat1, Plat2, Plat3
    }
    public enum Dessert
    {
        None , Dessert1, Dessert2, Dessert3
    }

    [HideInInspector] public int restartCounter = 0;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
        fridgeInventory = new List<Item>();
    }

    private void Update()
    {
        switch(gameState)
        {
            case State.MENU:

                break;

            case State.HUB:
                
                break;
        }
        Debug.Log(StartersSelect);
    }

    public void GetUIAndToggles()
    {
        hubUI = GameObject.FindGameObjectWithTag("UI");
        toggles = hubUI.GetComponent<MenuUI>().menuToggles;
    }
    public void DishEffects()
    {
        if (toggles[1].isOn)
        {

        }
    }
    public void ConsumeOnRun()
    {
        for (int i = 0; i < toggles.Count ; i++)
        {
            if(toggles[i].isOn)
            {
                
                onionCount += toggles[i].GetComponent<CourseCost>().onionCost;
                eggplantCount += toggles[i].GetComponent<CourseCost>().eggplantCost;
                watermelonCount += toggles[i].GetComponent<CourseCost>().watermelonCost;
                tofuCount += toggles[i].GetComponent<CourseCost>().tofuCost;
                lemonCount += toggles[i].GetComponent<CourseCost>().lemonCost;
            }
        }

        for(int i = 0; i < onionCount; i++)
        {
            fridgeInventory.Remove(Item.ONION);
        }

        for (int i = 0; i < eggplantCount; i++)
        {
            fridgeInventory.Remove(Item.EGGPLANT);
        }

        for (int i = 0; i < watermelonCount; i++)
        {
            fridgeInventory.Remove(Item.WATERMELON);
        }

        for (int i = 0; i < tofuCount; i++)
        {
            fridgeInventory.Remove(Item.TOFU);
        }

        for (int i = 0; i < lemonCount; i++)
        {
            fridgeInventory.Remove(Item.LEMON);
        }

        onionCount = 0;
        watermelonCount = 0;
        lemonCount = 0;
        eggplantCount = 0;
        tofuCount = 0;
    }

    

}
