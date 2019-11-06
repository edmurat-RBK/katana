using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeContent : MonoBehaviour
{
    //List of every loot in the game
    [SerializeField]
    private GameObject onion;
    [HideInInspector] public int onionCount = 0;
    [SerializeField]
    private GameObject lemon;
    [HideInInspector] public int lemonCount = 0;
    [SerializeField]
    private GameObject watermelon;
    [HideInInspector] public int watermelonCount = 0;
    [SerializeField]
    private GameObject eggplant;
    [HideInInspector] public int eggplantCount = 0;

    public List<GameObject> loot = new List<GameObject>();

    // Open and closed sprite
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    public Sprite openSprite, closedSprite;
    bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            AddToFridge(lemon);
        }
        for (int i = 0; i < 3; i++)
        {
            AddToFridge(onion);
        }
        for (int i = 0; i < 1; i++)
        {
            AddToFridge(eggplant);
        }
        for (int i = 0; i < 7; i++)
        {
            AddToFridge(watermelon);
        }
        InitFridge();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddToFridge(GameObject lootable)
    {
        loot.Add(lootable);
    }

    void RemovefromFridge(GameObject lootable)
    {
        loot.Remove(lootable);
    }

    void InitFridge()
    {
        for (int i = 0; i < loot.Count; i++)
        {
            if (loot[i] == watermelon)
            {
                watermelonCount++;
            }

            if (loot[i] == onion)
            {
                onionCount++;
            }
            if (loot[i] == eggplant)
            {
                eggplantCount++;
            }

            if (loot[i] == lemon)
            {
                lemonCount++;
            }
        }
    }//Quand on entre dans le HUB on initialise le contenu du frigo en fonction des items qu'on a ramassé

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetButtonDown("Pick"))
        {
            if (isOpen)
            {
                Debug.Log("Onion: " + onionCount + ", Lemon: " + lemonCount + ", Eggplant: " + eggplantCount + ", Watermelon: " + watermelonCount + ".");
            }
            else
            {
                isOpen = true;
                spriteRenderer.sprite = openSprite;
            }               
        }            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOpen = false;
        spriteRenderer.sprite = closedSprite;
    }
}
