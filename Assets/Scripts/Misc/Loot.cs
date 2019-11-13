using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public Item item;
    public float maximumPickupTime = 5f;
    [HideInInspector] public float pickupTime;
    public bool isPickup = false;
    public bool isThrow = false;
    private float floatingEffect = 0f;

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
            pickupTime = 0;
            Destroy(gameObject);
        }
        else
        {
            if(!isPickup && !isThrow)
            {
                pickupTime -= Time.deltaTime;
            }
        }

        if(!isPickup && !isThrow)
        {
            floatingEffect += 0.05f;
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f * Mathf.Sin(floatingEffect), 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Replace with "Walls" tag when created
        if(!other.CompareTag("Player") && !other.CompareTag("Enemy") && !other.CompareTag("Spawnpoint") && !other.CompareTag("Basket"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            isThrow = false;
        }
    }

    public float GetTimeleftinPercentage()
    {
        return 1 - (pickupTime / maximumPickupTime);
    }

}
