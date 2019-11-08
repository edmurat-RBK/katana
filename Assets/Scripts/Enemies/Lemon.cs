using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemon : Enemy
{
    //Liste des directions 
    enum Direction                  { UP, DOWN, LEFT, RIGHT, NONE }
    private Direction               directionToMove = Direction.NONE;

    //Gestion de la détection et de la vitesse
    [SerializeField] private float  fuiteDist = .5f;
    [SerializeField] private float  speedFuite = 1f;
    [SerializeField] private float  offsetDetectionRange = .01f;
    private Transform               targetTransform;
    [SerializeField] private float  detectionRadius;

    //Animator
    private Animator                anim;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        targetTransform = target.transform;
    }

    void Update()
    {

        DirectionToMoveAway();

        if (Vector3.Distance(transform.position, targetTransform.position) < detectionRadius)
        {
            MoveTowardsTarget(targetTransform);
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("isMoving", false);
        }

        // déplacements de fuite 
        if (Vector3.Distance(transform.position, targetTransform.position) < fuiteDist)
        {     
            MoveAway();
        }
        else
        {

        }

        anim.SetFloat("horizontalMove", rb.velocity.x);
        anim.SetFloat("verticalMove", rb.velocity.y);
    }

    private void MoveTowardsTarget(Transform targ) //déplacement sur le x ou le y du joueur
    {
        if (Mathf.Abs(targ.position.x - transform.position.x) > Mathf.Abs(targ.position.y - transform.position.y))
        {
            rb.velocity = new Vector2(0f, (targ.position.y - transform.position.y)) * speed;
            anim.SetBool("isMoving", true);
        }
        else
        {
            rb.velocity = new Vector2((targ.position.x - transform.position.x), 0f) * speed;
            anim.SetBool("isMoving", true);
        }
    }

    private void MoveAway()
    {
        switch (directionToMove)
        {
            case Direction.UP:
                rb.velocity = new Vector2(0f, 1f) * speedFuite;
                anim.SetBool("isMoving", true);
                break;
            case Direction.DOWN:
                rb.velocity = new Vector2(0f, -1f) * speedFuite;
                anim.SetBool("isMoving", true);
                break;
            case Direction.LEFT:
                rb.velocity = new Vector2(-1f, 0f) * speedFuite;
                anim.SetBool("isMoving", true);
                break;
            case Direction.RIGHT:
                rb.velocity = new Vector2(1f, 0f) * speedFuite;
                anim.SetBool("isMoving", true);
                break;
        }
    }

    private void DirectionToMoveAway()//détermine la direction de fuite
    {
        if (transform.position.x <= targetTransform.position.x + offsetDetectionRange
            && transform.position.x >= targetTransform.position.x - offsetDetectionRange)
        {
            if (transform.position.y < targetTransform.position.y)
            {
                directionToMove = Direction.DOWN;
            }
            if (transform.position.y > targetTransform.position.y)
            {
                directionToMove = Direction.UP;
            }
        }
        if (transform.position.y <= targetTransform.position.y + offsetDetectionRange
            && transform.position.y >= targetTransform.position.y - offsetDetectionRange)
        {
            if (transform.position.x < targetTransform.position.x)
            {
                directionToMove = Direction.LEFT;
            }
            if (transform.position.x > targetTransform.position.x)
            {
                directionToMove = Direction.RIGHT;
            }
        }
    }
}
