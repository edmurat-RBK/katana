using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{

    private List<Item> content;

    // Start is called before the first frame update
    void Start()
    {
        content = new List<Item>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Loot"))
        {
            if(other.GetComponent<Loot>().isThrow)
            {
                content.Add(other.GetComponent<Loot>().item);
                Destroy(other.gameObject);
            }
            else if(other.GetComponent<Loot>().isPickup)
            {
                content.Add(other.GetComponent<Loot>().item);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isHolding = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().speedModifier = 1f;
                Destroy(other.gameObject);
            }
        }
    }
}
