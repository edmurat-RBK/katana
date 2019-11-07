using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public enum Direction
    {
        NORTH = 1,
        EAST = 2,
        SOUTH = 3,
        WEST = 4,
        NONE = 0
    }

    private Rigidbody2D rb;
    public float speed;
    public Direction direction;
    private float maximumLifetime = 10f;
    private float lifetime;
    public float rotationSpeed = 0.01f;
    public float attackDamage = 0.5f;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(direction == Direction.NORTH)
        {
            rb.velocity = Vector2.up * speed;
        }
        else if (direction == Direction.EAST)
        {
            rb.velocity = Vector2.right * speed;
        }
        else if (direction == Direction.SOUTH)
        {
            rb.velocity = Vector2.down * speed;
        }
        else if (direction == Direction.WEST)
        {
            rb.velocity = Vector2.left * speed;
        }

        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationSpeed, 0f);

        lifetime += Time.deltaTime;
        if(lifetime >= maximumLifetime)
        {
            Destroy(gameObject);
        }
    }
}
