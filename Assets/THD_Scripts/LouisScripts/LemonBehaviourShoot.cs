using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonBehaviourShoot : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float offsetDetectionRange = .01f;
    enum Direction { UP, DOWN, LEFT, RIGHT, NONE }
    private Direction directionToShoot = Direction.NONE;
    [SerializeField]
    private float ShootDist = .10f;


    // Update is called once per frame
    void Update()
    {
        DirectionToShoot();
        TurnShoot();
        // distance de tir
        if (Vector3.Distance(transform.position, target.position) < ShootDist)
        { }
        
    }
    void TurnShoot()// rotation (pour l'instant)
    {
        switch (directionToShoot)
        {
            case Direction.UP:
                transform.eulerAngles = new Vector3(0, 0, 180);
                Debug.Log("up");
                break;
            case Direction.DOWN:
                transform.eulerAngles = new Vector3(0, 0, 0);
                Debug.Log("down");
                break;
            case Direction.LEFT:
                transform.eulerAngles = new Vector3(0, 0, -90);
                Debug.Log("left");
                break;
            case Direction.RIGHT:
                transform.eulerAngles = new Vector3(0, 0, 90);
                Debug.Log("right");
                break;
        }
    }
    private void DirectionToShoot()//détermine la direction de tir
    {
        if (transform.position.x <= target.position.x + offsetDetectionRange
            && transform.position.x >= target.position.x - offsetDetectionRange)
        {
            //Debug.Log("Detected");
            if (transform.position.y < target.position.y)
            {
                directionToShoot = Direction.UP;
                
            }
            if (transform.position.y > target.position.y)
            {
                directionToShoot = Direction.DOWN;
                
            }
        }
        if (transform.position.y <= target.position.y + offsetDetectionRange
            && transform.position.y >= target.position.y - offsetDetectionRange)
        {
            //Debug.Log("Detected");
            if (transform.position.x < target.position.x)
            {
                directionToShoot = Direction.RIGHT;
                
            }
            if (transform.position.x > target.position.x)
            {
                directionToShoot = Direction.LEFT;
                
            }
        }
    }
}
