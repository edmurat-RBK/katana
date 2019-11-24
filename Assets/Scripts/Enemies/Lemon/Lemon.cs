using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lemon : Enemy
{
    //Liste des directions----------------------------------------------- 
    enum Direction                  { UP, DOWN, LEFT, RIGHT, NONE }
    private Direction               directionToMove = Direction.NONE;
    private Direction               directionToShoot = Direction.NONE;

    //Gestion de la détection et de la vitesse---------------------------
    [SerializeField] private float  fuiteDist = .5f;
    [SerializeField] private float  speedFuite = 1f;
    [SerializeField] private float  offsetDetectionRange = .01f;
    private Transform               targetTransform;
    [SerializeField] private float  detectionRadius;



    //Shoot--------------------------------------------------------------
    public Transform                firePoint;
    public GameObject               lemonProjectile;
    public float                    bulletForce = 10f;
    private int                     rate;
    public int                      initRate = 100;



    private void Start()
    {
        OnStart();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        targetTransform = player.transform;
        rate = initRate;
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

        if (Vector3.Distance(transform.position, targetTransform.position) < fuiteDist)
        {     
            MoveAway();
        }
        else
        {

        }

        DirectionToShoot();
        Turn();
 

        if (Vector3.Distance(transform.position, targetTransform.position) < detectionRadius)
        {
            rate--;
            if (rate <= 0)
            {
                Shoot();
                Debug.Log("tir");
                rate = initRate;
            }
        }

        anim.SetFloat("horizontalMove", rb.velocity.x);
        anim.SetFloat("verticalMove", rb.velocity.y);
    }

    private void MoveTowardsTarget(Transform targ)
    {
        if (Mathf.Abs(targ.position.x - transform.position.x) > Mathf.Abs(targ.position.y - transform.position.y))
        {
            rb.velocity = new Vector2(0f, (targ.position.y - transform.position.y)) * baseSpeed;
            anim.SetBool("isMoving", true);
        }
        else
        {
            rb.velocity = new Vector2((targ.position.x - transform.position.x), 0f) * baseSpeed;
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

    private void DirectionToShoot()
    {
        if (transform.position.x <= targetTransform.position.x + offsetDetectionRange
            && transform.position.x >= targetTransform.position.x - offsetDetectionRange)
        {

            if (transform.position.y < targetTransform.position.y)
            {
                directionToShoot = Direction.UP;

            }
            if (transform.position.y > targetTransform.position.y)
            {
                directionToShoot = Direction.DOWN;

            }
        }
        if (transform.position.y <= targetTransform.position.y + offsetDetectionRange
            && transform.position.y >= targetTransform.position.y - offsetDetectionRange)
        {
            if (transform.position.x < targetTransform.position.x)
            {
                directionToShoot = Direction.RIGHT;

            }
            if (transform.position.x > targetTransform.position.x)
            {
                directionToShoot = Direction.LEFT;

            }
        }
    }

    void Shoot()
    {
        GameObject tirCitron = Instantiate(lemonProjectile, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = tirCitron.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
    void Turn()
    {
        switch (directionToShoot)
        {
            case Direction.UP:
                firePoint.eulerAngles = new Vector3(0, 0, 0);
                break;
            case Direction.DOWN:
                firePoint.eulerAngles = new Vector3(0, 0, 180);
                break;
            case Direction.LEFT:
                firePoint.eulerAngles = new Vector3(0, 0, 90);
                break;
            case Direction.RIGHT:
                firePoint.eulerAngles = new Vector3(0, 0, -90);
                break;
        }
    }
}
