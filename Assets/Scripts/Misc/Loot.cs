using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public enum Item
    {
        ONION = 1,
        WATERMELON = 2,
        LEMON = 3,
        EGGPLANT = 4
    }

    public Item item;
    public float maximumPickupTime = 5f;
    [HideInInspector] public float pickupTime;
    public bool isPickup = false;
    public bool isThrow = false;

    // Start is called before the first frame update
    void Start()
    {
        pickupTime = maximumPickupTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(pickupTime <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            if(!isPickup && !isThrow)
            {
                pickupTime -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Replace with "Walls" tag when created
        if(!other.CompareTag("Player") && !other.CompareTag("Ennemy") && !other.CompareTag("Spawnpoint") && !other.CompareTag("Basket"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isThrow = false;
        }
    }
}
