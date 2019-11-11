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
    private bool isMoving = false;
    private bool isDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (directionToMove == Direction.NONE)
        {
            SearchTarget();
        }

        if(isDead)
        {
            
            Loot();
            Destroy(gameObject);
        }
            
        switch (directionToMove)
        {

            case Direction.UP:
                rb.velocity = new Vector2(0f,1f) * speed;
                anim.SetBool("isMoving", true);
                isMoving = true;
                break;
            case Direction.DOWN:
                rb.velocity = new Vector2(0f, -1f) * speed;
                anim.SetBool("isMoving", true);
                isMoving = true;
                break;
            case Direction.LEFT:
                rb.velocity = new Vector2(1f, 0f) * speed;
                anim.SetBool("isMoving", true);
                isMoving = true;
                break;
            case Direction.RIGHT:
                rb.velocity = new Vector2(-1f, 0f) * speed;
                anim.SetBool("isMoving", true);
                isMoving = true;
                break;
        }

        Orientation();
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
        rb.velocity = Vector2.zero;
        if (collision.collider.CompareTag("Player") && isMoving)
        {   
            anim.SetBool("isDead", true);
            target.GetComponent<Player>().TakeDamage(attackDamage);    
        }
        if (isMoving)
        {
            anim.SetBool("isDead", true);
        }
    }

    public void OnDeathAnimation()
    {
        isDead = true;
    }

    public void Orientation()
    {
        float horizontalOrientation = target.transform.position.x - transform.position.x;
        float verticalOrientation = target.transform.position.y - transform.position.y;
        anim.SetFloat("verticalOrientation", verticalOrientation);
        anim.SetFloat("horizontalOrientation", horizontalOrientation);
    }
}
