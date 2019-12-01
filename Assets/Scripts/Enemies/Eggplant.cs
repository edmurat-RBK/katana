using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Eggplant : Enemy
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

    //Particle
    public GameObject fxOnde;
    public GameObject fxDeadEggplant;

    //Audio
    



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

        if(cameraShakeController.GetComponent<CameraShake>().isShaking)
        {
            cameraShakeController.GetComponent<CameraShake>().CameraShaking(0.3f, 1.2f, 2f);
        }
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
            isAttacking = false;
        }
    }

    void Movement()
    {   
        if (Vector3.Distance(transform.position, target.position) >= stoppingDistance && !isAttacking)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * (baseSpeed * speedModifier);
            anim.SetBool("isMoving", true);
        }

        else
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("isMoving", false);
        }   
        
        if(isAttacking)
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
                    isAttacking = true;
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    gameObject.GetComponent<CircleCollider2D>().enabled = false;
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
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            player.GetComponent<Player>().TakeDamage(attackDamage); 
        }    
    }

    public void GetAnimationEvent(string eventMessage)
    {
        if (eventMessage.Equals("AttackEnded"))
        {
            GetComponent<AudioSource>().Play();   
            startShockwave = true;
            shockwaveCooldown = initialAttackCooldown;
            anim.SetBool("isAttacking", false);
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            cameraShakeController.GetComponent<CameraShake>().isShaking = true ;
        }

        if (eventMessage.Equals("Death"))
        {
            isDead = true;
        }

        if (eventMessage.Equals("Hit"))
        {
            anim.SetBool("isDamage", false);
        }

        if (eventMessage.Equals("StartFX"))
        {
            fxOnde.GetComponent<ParticleSystem>().Play();
        }

        if (eventMessage.Equals("isDead"))
        {
            fxDeadEggplant.GetComponent<ParticleSystem>().Play();
        }
    }
}
