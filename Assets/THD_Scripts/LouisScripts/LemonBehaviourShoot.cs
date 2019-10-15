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
    public Transform firePoint;
    public GameObject tirCitronPrefab;
    public float bulletForce = 20f;
    private int rate;
    public int initRate = 100;

    private void Start()
    {
        rate = initRate;
    }

    // Update is called once per frame
    void Update()
    {

        DirectionToShoot();
        Turn();
        // distance de tir
        if (Vector3.Distance(transform.position, target.position) < ShootDist)
        {
            rate--;
            if (rate<=0)
            {
                Shoot();
                Debug.Log("tir");
                rate = initRate;
            }
        }
        
    }

    void Shoot()
    {
        GameObject tirCitron = Instantiate(tirCitronPrefab, firePoint.position, firePoint.rotation);//spawn tir
        tirCitron.transform.SetParent(this.transform);// on declare la bullet en enfant de lemon
        Rigidbody2D rb = tirCitron.GetComponent<Rigidbody2D>(); //on y ajoute un rigidbody
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);// on y ajoute la force
    }
    void Turn()// rotation (pour l'instant)
    {
        switch (directionToShoot)
        {
            case Direction.UP:
                firePoint.eulerAngles = new Vector3(0, 0, 0);
                Debug.Log("up");
                break;
            case Direction.DOWN:
                firePoint.eulerAngles = new Vector3(0, 0, 180);
                Debug.Log("down");
                break;
            case Direction.LEFT:
                firePoint.eulerAngles = new Vector3(0, 0, 90);
                Debug.Log("left");
                break;
            case Direction.RIGHT:
                firePoint.eulerAngles = new Vector3(0, 0, -90);
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
