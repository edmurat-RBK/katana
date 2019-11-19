using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggplant : NewEnemy
{
    //public float t;
    bool startShockwave;

    //Movement 
    Transform target;
    public float stoppingDistance;

    //Shockwave
    private float shockwaveCooldown;
    CircleCollider2D shockwave;
    public float sizeDiffShock;   
    public float speedShockWave;


    // Start is called before the first frame update
    void Start()
    {
        OnStart();
        target = player.transform ;
        shockwave = GetComponent<CircleCollider2D>();
        shockwaveCooldown = initialAttackCooldown;
        startShockwave = false;
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
        EggplantAttack();

        Movement();
        Orientation();

        anim.SetFloat("horizontalMovement", rb.velocity.x);
        anim.SetFloat("verticalMovement", rb.velocity.y);
    }

    private void FixedUpdate()
    {
        if (startShockwave)
        {
            shockwave.radius += speedShockWave * Time.deltaTime;
        }
        if (shockwave.radius >= stoppingDistance + sizeDiffShock)
        {
            startShockwave = false;
            shockwave.radius = 0;
        }
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

    void EggplantAttack()
    {

            if (Vector3.Distance(target.position, transform.position) <= stoppingDistance)
            {
                rb.velocity = Vector2.zero;
                if(shockwaveCooldown <= 0)
                {
                    anim.SetBool("isAttacking", true);
                }
                else
                {
                    shockwaveCooldown -= Time.deltaTime;
                }

            }  
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shockwave.radius);
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("TakeDamage");
            player.GetComponent<Player>().TakeDamage(attackDamage);
        }
        
    }

    public void GetAnimationEvent(string eventMessage)
    {
        if (eventMessage.Equals("AttackEnded"))
        {
            startShockwave = true;
            shockwaveCooldown = initialAttackCooldown;
            anim.SetBool("isAttacking", false);
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
