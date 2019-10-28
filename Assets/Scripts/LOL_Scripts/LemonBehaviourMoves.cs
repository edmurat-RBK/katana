using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonBehaviourMoves : EnemyBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speedFuite = 1f;
    [SerializeField]
    private float offsetDetectionRange = .01f;
    enum Direction { UP, DOWN, LEFT, RIGHT, NONE }
    private Direction directionToMove = Direction.NONE;
    [SerializeField]
    private float fuiteDist = .5f;



    // Update is called once per frame
    void Update()
    {
        
        DirectionToMoveAway();

        // déplacements de fuite 
        if (Vector3.Distance(transform.position, target.position) < fuiteDist)
        {
            MoveAway();
        }
            

        // déplacement pour s'aligner au joueur
        MoveTowardsTarget(target);

    }

    private void MoveTowardsTarget(Transform targ) //déplacement sur le x ou le y du joueur
    {
        if (Mathf.Abs(targ.position.x - transform.position.x) > Mathf.Abs(targ.position.y - transform.position.y))
        {
            transform.position += new Vector3(0, (targ.position.y - transform.position.y), 0) * speed * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3((targ.position.x - transform.position.x), 0, 0) * speed * Time.deltaTime;
        }
    }

    private void MoveAway()// vecteurs qui font fuir
    {
        switch (directionToMove)
        {
            case Direction.UP:
                transform.position += new Vector3(0, 1, 0) * speedFuite * Time.deltaTime;
                break;
            case Direction.DOWN:
                transform.position += new Vector3(0, -1, 0) * speedFuite * Time.deltaTime;
                break;
            case Direction.LEFT:
                transform.position += new Vector3(-1, 0, 0) * speedFuite * Time.deltaTime;
                break;
            case Direction.RIGHT:
                transform.position += new Vector3(1, 0, 0) * speedFuite * Time.deltaTime;
                break;
        }
    }

    private void DirectionToMoveAway()//détermine la direction de fuite
    {
        if (transform.position.x <= target.position.x + offsetDetectionRange
            && transform.position.x >= target.position.x - offsetDetectionRange)
        {
            //Debug.Log("Detected");
            if (transform.position.y < target.position.y)
            {
                directionToMove = Direction.DOWN;
            }
            if (transform.position.y > target.position.y)
            {
                directionToMove = Direction.UP;
            }
        }
        if (transform.position.y <= target.position.y + offsetDetectionRange
            && transform.position.y >= target.position.y - offsetDetectionRange)
        {
            //Debug.Log("Detected");
            if (transform.position.x < target.position.x)
            {
                directionToMove = Direction.LEFT;
            }
            if (transform.position.x > target.position.x)
            {
                directionToMove = Direction.RIGHT;
            }
        }
    }
}
