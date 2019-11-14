using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    private GameManager gameManager;
    public Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Loot"))
        {
            if(other.GetComponent<Loot>().isThrow)
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
}
