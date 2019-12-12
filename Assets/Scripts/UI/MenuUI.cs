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

    public List<Toggle> menuToggles = new List<Toggle>();

    //Text 
    [Header("Inventory")]
    public GameObject eggplantNumber;
    public GameObject onionNumber;
    public GameObject lemonNumber;
    public GameObject watermelonNumber;
    public GameObject tofuNumber;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsPaused && Input.GetButtonDown("MeleeAttack"))
        {
            Resume();
        }
    }

    public void Pause()
    {
        menuUI.SetActive(true);
        eventSystem.GetComponent<EventSystem>().firstSelectedGameObject = firstSelectedObject;
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstSelectedObject);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void ResetMenu()
    {
        for(int i = 0; i < menuToggles.Count; i++)
        {
            menuToggles[i].isOn = false;
        }
    }
}
