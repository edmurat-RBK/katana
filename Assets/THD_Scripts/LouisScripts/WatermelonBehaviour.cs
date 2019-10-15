using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatermelonBehaviour : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float offsetDetectionRange = .075f;
    [SerializeField]
    private float speed = 1f;
    enum Direction
    {
        UP, DOWN, LEFT, RIGHT, NONE
    }
    private Direction directionToMove = Direction.NONE;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (directionToMove == Direction.NONE)
            SearchTarget();
        switch (directionToMove)//deplacements via des vecteurs
        {

            case Direction.UP:
                transform.position += new Vector3(0, 1, 0) * speed;
                break;
            case Direction.DOWN:
                transform.position += new Vector3(0, -1, 0) * speed;
                break;
            case Direction.LEFT:
                transform.position += new Vector3(1, 0, 0) * speed;
                break;
            case Direction.RIGHT:
                transform.position += new Vector3(-1, 0, 0) * speed;
                break;
        }
    }
    
    private void SearchTarget() //recherche du joueur dans les colonnes definies par offsetdetectionrange
    {
        if (transform.position.x <= target.position.x + offsetDetectionRange && transform.position.x >= target.position.x - offsetDetectionRange)
        {
            //Debug.Log("Detected");
            if (transform.position.y < target.position.y)
            {
                directionToMove = Direction.UP;
            }
            if (transform.position.y > target.position.y)
            {
                directionToMove = Direction.DOWN;
            }
        }
        if (transform.position.y <= target.position.y + offsetDetectionRange && transform.position.y >= target.position.y - offsetDetectionRange)
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
