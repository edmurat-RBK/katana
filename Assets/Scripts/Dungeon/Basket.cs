using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    private GameManager gameManager;
    private Animator anim;
    private Animator playerAnim;
    private Player player;

    private bool openChest = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Loot"))
        {
            if (other.GetComponent<Loot>().isThrow)
            {
                gameManager.fridgeInventory.Add(other.GetComponent<Loot>().item);
                Destroy(other.gameObject);
            }
            else if(other.GetComponent<Loot>().isPickup)
            {
                gameManager.fridgeInventory.Add(other.GetComponent<Loot>().item);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isHolding = false;
                playerAnim.SetBool("isHolding", false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().speedModifier = 1f;
                Destroy(other.gameObject);
            }
        }
    }

    private void Update()
    {
        GameObject[] loot = GameObject.FindGameObjectsWithTag("Loot");
        openChest = false;
        foreach (GameObject go in loot)
        {
            if(go.GetComponent<Loot>().isThrow || go.GetComponent<Loot>().isPickup)
            {
                openChest = true;
            }
        }

        if(openChest)
        {
            anim.SetBool("openChest", true);
        }
        else
        {
            anim.SetBool("openChest", false);
        }
    }
}
