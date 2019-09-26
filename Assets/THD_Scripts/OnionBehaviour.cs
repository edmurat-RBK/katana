using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionBehaviour : EnemyBehaviour
{
    Transform target;
    public float stoppingDistance;
    public float attackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        OnionMovement(); 
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnionMovement()
    {   
        if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
        
    }

   /* void OnionAttack()
    {

        if (attackCoolDown <= 0)
        {
            //Do something
            //reinit cooldown
        }
        else
        {
            attackCooldown--;
        }
    }*/
}
