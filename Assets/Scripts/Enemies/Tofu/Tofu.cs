using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tofu : Enemy
{ 
    //Clone Spawning
    float SpawnCooldown;
    public float iSpawnCooldown;
    public GameObject tofuClone;

    //Movement
    private Transform target;
    public float stoppingDistance;


    // Start is called before the first frame update
    void Start()
    {
        OnStart();
        target = player.transform;
        SpawnCooldown = iSpawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
        Movement();
        Orientation();
        CloneSpawn();

        anim.SetFloat("horizontalMovement", rb.velocity.x);
        anim.SetFloat("verticalMovement", rb.velocity.y);
    }
    void Movement()
    {
        if (Vector3.Distance(transform.position, target.position) >= stoppingDistance)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * (baseSpeed * speedModifier);
            anim.SetBool("isMoving", true);
        }
           
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("isMoving", false);
        }
    }
    void CloneSpawn()
    {
        if (Vector3.Distance(target.position, transform.position) <= stoppingDistance)
        {
            rb.velocity = Vector2.zero;
            if (SpawnCooldown <= 0)
            {                
                anim.SetBool("isAttacking", true);
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
            else
            {
                SpawnCooldown--;
            }
        }

        
    }
    public void GetAnimationEvent(string eventMessage)
    {
        if (eventMessage.Equals("AttackEnded"))
        {
            Instantiate(tofuClone, transform.position, transform.rotation);
            anim.SetBool("isAttacking", false);
            SpawnCooldown = iSpawnCooldown;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (eventMessage.Equals("Death"))
        {
            isDead = true; 
        }

        if (eventMessage.Equals("Hit"))
        {
            anim.SetBool("isDamage", false);
        }
    }
}
