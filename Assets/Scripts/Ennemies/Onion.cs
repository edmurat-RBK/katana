using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : Enemy
{
    private Animator        anim;
    public float            stoppingDistance;
    public ParticleSystem   onionSpray;
    public Transform        pos;
    public bool             isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        pos = target.transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        anim.SetFloat("horizontalMove", rb.velocity.x);
        anim.SetFloat("verticalMove", rb.velocity.y);
        if (health <= 0 && !isDead)
        {
            Loot();
            Destroy(gameObject);
            isDead = true;
        }

    }


    private void Movement()
    {
        if (!isAttacking)
        {
            if (Vector2.Distance(transform.position, pos.position) > stoppingDistance)
            {
                rb.velocity = (pos.position - transform.position).normalized * speed;
            }
            else
            {
                rb.velocity = Vector2.zero;
            }
            
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }


    
}
