using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionBehaviour : EnemyBehaviour
{
    Transform target;
    public float stoppingDistance;
    float attackCooldown;
    public float iattackCooldown;
    public float attackRange;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        attackCooldown = iattackCooldown;
        

    }

    // Update is called once per frame
    void Update()
    {
        OnionMovement(); 
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        OnionAttack();
    }

    void OnionMovement()
    {   
        if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
        //Quand l'oignon est proche du joueur, alors il lui tourne autour ?
        
    }

    void OnionAttack()
    {
        if (attackCooldown <= 0)
        {     
            if (Vector3.Distance(target.position, transform.position) <= attackRange)
            {
                GameObject.Find("Player").GetComponent<CharacterMovement>().health -= 1;
                Debug.Log(GameObject.Find("Player").GetComponent<CharacterMovement>().health);
                //Blur
            }
            attackCooldown = iattackCooldown;
        }
        else
        {
            attackCooldown--;
        }

    }
}
