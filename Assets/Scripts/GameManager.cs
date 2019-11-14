using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        fridgeInventory = new List<Item>();
    }

    private void Update()
    {
        switch(gameState)
        {
            case State.MENU:

                break;
        }
    }
}
