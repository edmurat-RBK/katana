using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watermelon : Enemy
{

    [SerializeField]
    private float offsetDetectionRange = .75f;
    enum Direction
    {
        UP, DOWN, LEFT, RIGHT, NONE
    }
    private Direction directionToMove = Direction.NONE;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (directionToMove == Direction.NONE)
            SearchTarget();
        switch (directionToMove)
        {

            case Direction.UP:
                transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
                break;
            case Direction.DOWN:
                transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
                break;
            case Direction.LEFT:
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
                break;
            case Direction.RIGHT:
                transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
                break;
        }

        anim.SetFloat("horizontalMove", rb.velocity.x);
        anim.SetFloat("verticalMove", rb.velocity.y);
    }

    private void SearchTarget() //recherche du joueur dans les colonnes definies par offsetdetectionrange
    {
        if (transform.position.x <= target.transform.position.x + offsetDetectionRange && transform.position.x >= target.transform.position.x - offsetDetectionRange)
        {
            //Debug.Log("Detected");
            if (transform.position.y < target.transform.position.y)
            {
                directionToMove = Direction.UP;
            }
            if (transform.position.y > target.transform.position.y)
            {
                directionToMove = Direction.DOWN;
            }
        }
        if (transform.position.y <= target.transform.position.y + offsetDetectionRange && transform.position.y >= target.transform.position.y - offsetDetectionRange)
        {
            //Debug.Log("Detected");
            if (transform.position.x < target.transform.position.x)
            {
                directionToMove = Direction.LEFT;
            }
            if (transform.position.x > target.transform.position.x)
            {
                directionToMove = Direction.RIGHT;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//Quand la pastèque rencontre un collider, elle est détruite.
    {
        Destroy(gameObject);
    }
}
