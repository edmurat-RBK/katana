using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : Enemy
{
    private Rigidbody2D     rb;
    private Animator        anim;
    public float            stoppingDistance;
    public ParticleSystem   onionSpray;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OnDeathAttack();
        anim.SetFloat("horizontalMove", rb.velocity.x);
        anim.SetFloat("verticalMove", rb.velocity.y); 
    }


    private void Movement()
    {
        if (!isAttacking)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > stoppingDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
            }
        }

        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnDeathAttack()
    {
        if(health <= 0)
        {
            rb.velocity = Vector2.zero;//il arrête de bouger
            //lancer l'anim de mort
            //à la fin de l'anim lancer une coroutine avec l'effet;
        }

    }
}
