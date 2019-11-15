using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TofuClone : NewEnemy
{
    
    public float timetodeath = 100;
    public float triggerExplosionDistance;
    
    bool triggered = false;
    public float cooldownSuicide;

    //Explosion
    CircleCollider2D explosion;
    public float tailleExplosion;

    //Movement
    private Transform target;

    void Start()
    {
        OnStart();
        target = player.transform;
        explosion = GetComponent<CircleCollider2D>();
    }
    void Update()
    {
        OnUpdate();
        NarutofuCloneMovement();
        NarutofuCloneExplosionTrigger();

        Orientation();
        anim.SetFloat("horizontalMovement", rb.velocity.x);
        anim.SetFloat("verticalMovement", rb.velocity.y);
    }
    private void FixedUpdate()
    {
        NarutofuCloneAging();
        NarutofuCloneExplosion();
    }
    void NarutofuCloneMovement()
    {
        if (!triggered)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * (baseSpeed * speedModifier);
            anim.SetBool("isMoving",true);
        }
        else
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("isMoving", false);
        }
    }
    void NarutofuCloneAging()
    {
        if (timetodeath >= 0 && !triggered)
        {
            timetodeath--;
        }
        if (timetodeath == 0)
        {
            anim.SetBool("isDead", true);
        }
    }
    void NarutofuCloneExplosionTrigger()
    {
        if (Vector3.Distance(transform.position, target.position) < triggerExplosionDistance)
        {
            triggered = true;
        }
    }
    void NarutofuCloneExplosion()
    {
        if (triggered == true)
        {
            cooldownSuicide--;
        }

        if (cooldownSuicide <= 0)
        {
            anim.SetBool("isExploding", true);
        }   
    }

    public void GetAnimationEvent(string eventMessage)
    {
        if (eventMessage.Equals("Explosion"))
        {
            explosion.radius = tailleExplosion;
        }

        if(eventMessage.Equals("ExplosionEnded"))
        {
            Destroy(gameObject);
        }

        if(eventMessage.Equals("Death"))
        {
            Destroy(gameObject);
        }   
    }
}
