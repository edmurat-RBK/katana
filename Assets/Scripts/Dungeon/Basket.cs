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
        Debug.Log("Pik 0");
        if(other.CompareTag("Loot"))
        {
            Debug.Log("Pik 1");
            if (other.GetComponent<Loot>().isThrow)
            {
                Debug.Log("Pik 21");
                gameManager.fridgeInventory.Add(other.GetComponent<Loot>().item);
                Destroy(other.gameObject);
            }
            else if(other.GetComponent<Loot>().isPickup)
            {
                Debug.Log("Pik 22");
                gameManager.fridgeInventory.Add(other.GetComponent<Loot>().item);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isHolding = false;
                playerAnim.SetBool("isHolding", false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().speedModifier = 1f;
                Destroy(other.gameObject);
            }
        }
    }
}
