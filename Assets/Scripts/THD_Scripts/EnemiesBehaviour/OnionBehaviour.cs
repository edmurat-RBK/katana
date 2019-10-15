﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnionBehaviour : EnemyBehaviour
{
    Transform target;
    public float stoppingDistance;
    float attackCooldown;
    public float iattackCooldown;
    public float attackRange;
    bool isAttacking;

    public GameObject onionLoot; 




    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        attackCooldown = iattackCooldown;
        isAttacking = false ;
    }

    // Update is called once per frame
    void Update()
    {
        OnionAttack();
        OnionMovement(); 

        //The Onion dies
        if (health <= 0)
        {
            OnionLoot();
            Destroy(gameObject);
        }
        
    }

    void OnionMovement()
    {   
        if (isAttacking == false)
        {
            if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
            {
                
                if (Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed).x < 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                    Debug.Log("Facing Right");
                }
                transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);

               
            }

        }
       
        //Quand l'oignon est proche du joueur, alors il lui tourne autour ?        
    }

    void OnionAttack()
    {
        if (attackCooldown <= 0)//Cooldown de l'attaque de l'oignon
        {
            if (Vector3.Distance(target.position, transform.position) <= attackRange)
            {
                isAttacking = true;
                GameObject.Find("Player").GetComponent<CharacterMovement>().health -= 1;
                Debug.Log(GameObject.Find("Player").GetComponent<CharacterMovement>().health);
                //Blur
            }


            attackCooldown = iattackCooldown;
        }
        else
        {
            attackCooldown-- ;
            isAttacking = false ; 
        }

    }

    void OnionLoot()
    {
        Instantiate(onionLoot, new Vector3(transform.position.x,transform.position.y,0), Quaternion.identity);
        Debug.Log("wah le loot");
    }
}
