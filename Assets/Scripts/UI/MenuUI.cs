using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject firstSelectedObject;
    private bool gameIsPaused = false;
    public EventSystem eventSystem;
    private bool pressedOk = false;

    //Courses and Description
    public List<Toggle> menuToggles = new List<Toggle>();
    public List<Sprite> courseDescription = new List<Sprite>();
    public GameObject EntryDescription;
    public GameObject MainDescription;
    public GameObject DesertDescription;
    private Vector3 offset = new Vector3 (120f, 0f, 0f);

    //Text 
    [Header("Inventory")]
    public GameObject eggplantNumber;
    public GameObject onionNumber;
    public GameObject lemonNumber;
    public GameObject watermelonNumber;
    public GameObject tofuNumber;

    private GameManager gameManager;
    private int onionCount = 0;
    private int watermelonCount = 0;
    private int lemonCount = 0;
    private int eggplantCount = 0;
    private int tofuCount = 0;
    private int CurrentOnionCount = 0;
    private int CurrentWatermelonCount = 0;
    private int CurrentEggplantCount = 0;
    private int CurrentTofuCount = 0;


    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gameManager.GetUIAndToggles();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused && Input.GetButtonDown("MeleeAttack"))
        {
            Resume();
        }

        if (pressedOk && Input.GetButtonUp("Dash"))
        {
            Resume();
            CheckingOkButton();
            pressedOk = false;
        }
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        eventSystem.GetComponent<EventSystem>().firstSelectedGameObject = firstSelectedObject;
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstSelectedObject);
        Time.timeScale = 0f;
        gameIsPaused = true;
        StartCoroutine(UpdateMenu());
    }

    public void Resume()
    {
        ResetCount(); 
        Time.timeScale = 1f;
        menuUI.SetActive(false);
        gameIsPaused = false;
    }

    public void PressedOk()
    {
        pressedOk = true;
    }

    public void ResetMenu()
    {
        for(int i = 0; i < menuToggles.Count; i++)
        {
            menuToggles[i].isOn = false;
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

    private void UpdateCount()
    {
        for (int i = 0; i < gameManager.fridgeInventory.Count; i++)
        {
            switch (gameManager.fridgeInventory[i])
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

        eggplantNumber.GetComponent<Text>().text = eggplantCount.ToString();
        onionNumber.GetComponent<Text>().text = onionCount.ToString();
        lemonNumber.GetComponent<Text>().text = lemonCount.ToString();
        watermelonNumber.GetComponent<Text>().text = watermelonCount.ToString();
        tofuNumber.GetComponent<Text>().text = tofuCount.ToString();
    }

    private void SetTogglesDisabled() // Disable toggle if not enough ingredients
    {
        for (int i = 0; i < menuToggles.Count; i++)
        {
            CourseCost cost = menuToggles[i].GetComponent<CourseCost>();
            if(cost.onionCost > onionCount || cost.eggplantCost > eggplantCount || cost.watermelonCost > watermelonCount || cost.lemonCost > lemonCount || cost.tofuCost > tofuCount)
            {
                menuToggles[i].interactable = false;
            }
            else
            {
                menuToggles[i].interactable = true;
            }
         }
    }

    private IEnumerator UpdateMenu()
    {
        while(gameIsPaused)
        {
            UpdateCount();
            SetTogglesDisabled();
            yield return new WaitForSeconds(0.3f);
        }

        yield return null;
    }
    public void CourseDescription()
    {
        if(eventSystem.currentSelectedGameObject == menuToggles[0].gameObject)
        {
            EntryDescription.GetComponent<Image>().sprite = courseDescription[0];
            EntryDescription.transform.position += offset;
            
        }

        else if (eventSystem.currentSelectedGameObject == menuToggles[1].gameObject)
        {
            EntryDescription.GetComponent<Image>().sprite = courseDescription[1];
            EntryDescription.transform.position += offset;
        }

        else if (eventSystem.currentSelectedGameObject == menuToggles[2].gameObject)
        {
            EntryDescription.GetComponent<Image>().sprite = courseDescription[2];
            EntryDescription.transform.position += offset;
            
        }

        else if (eventSystem.currentSelectedGameObject == menuToggles[3].gameObject)
        {
            MainDescription.GetComponent<Image>().sprite = courseDescription[3];
            MainDescription.transform.position += offset;
        }

        else if (eventSystem.currentSelectedGameObject == menuToggles[4].gameObject)
        {
            MainDescription.GetComponent<Image>().sprite = courseDescription[4];
            MainDescription.transform.position += offset;
        }

        else if (eventSystem.currentSelectedGameObject == menuToggles[5].gameObject)
        {
            MainDescription.GetComponent<Image>().sprite = courseDescription[5];
            MainDescription.transform.position += offset;
        }

        else if (eventSystem.currentSelectedGameObject == menuToggles[6].gameObject)
        {
            DesertDescription.GetComponent<Image>().sprite = courseDescription[6];
            DesertDescription.transform.position += offset;
        }
        else if (eventSystem.currentSelectedGameObject == menuToggles[7].gameObject)
        {
            DesertDescription.GetComponent<Image>().sprite = courseDescription[7];
            DesertDescription.transform.position += offset;
        }
        else if (eventSystem.currentSelectedGameObject == menuToggles[8].gameObject)
        {
            DesertDescription.GetComponent<Image>().sprite = courseDescription[8];
            DesertDescription.transform.position += offset;
        }
    }

    #region ResetDescription
    public void ResetDescriptionEntry()
    {
        EntryDescription.transform.position -= offset;
    }

    public void ResetDescriptionMain()
    {
        MainDescription.transform.position -= offset;
    }

    public void ResetDescriptionDesert()
    {
        DesertDescription.transform.position -= offset;
    }
    #endregion

    public void CheckingOkButton()
    {
        for(int i = 0; i < menuToggles.Count; i++)
        {
            if (menuToggles[i].isOn)
            {
                if (menuToggles[i].name == "Entry_1")
                {
                    gameManager.StartersSelect = GameManager.Starters.Starter1;
                }
                if (menuToggles[i].name == "Entry_2")
                {
                    gameManager.StartersSelect = GameManager.Starters.Starter2;
                }
                if (menuToggles[i].name == "Entry_3")
                {
                    gameManager.StartersSelect = GameManager.Starters.Starter3;
                }
                if (menuToggles[i].name == "Main_1")
                {
                    gameManager.PlatSelect = GameManager.Plat.Plat1;
                }
                if (menuToggles[i].name == "Main_2")
                {
                    gameManager.PlatSelect = GameManager.Plat.Plat2;
                }
                if (menuToggles[i].name == "Main_3")
                {
                    gameManager.PlatSelect = GameManager.Plat.Plat3;
                }
                if (menuToggles[i].name == "Desert_1")
                {
                    gameManager.DessertSelect = GameManager.Dessert.Dessert1;
                }
                if (menuToggles[i].name == "Desert_2")
                {
                    gameManager.DessertSelect = GameManager.Dessert.Dessert2;
                }
                if (menuToggles[i].name == "Desert_3")
                {
                    gameManager.DessertSelect = GameManager.Dessert.Dessert3;
                }
            }
        }
    }
}
