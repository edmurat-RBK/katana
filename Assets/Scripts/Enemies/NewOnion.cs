using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOnion : NewEnemy
{
    public float minimumDistance;
    public float attackRadius;
    private bool atAttackRange = true;
    private bool isAttacking = false;
    public LayerMask playerLayerMask;

    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();

        if(!isAttacking)
        {
            Move();
        }

        Attack();
        Orientation();
    }

    private void Move()
    {
        if(Vector2.Distance(transform.position,player.transform.position) > minimumDistance)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * (baseSpeed * speedModifier);
            atAttackRange = false;
        }
        else
        {
            rb.velocity = Vector2.zero;
            atAttackRange = true;
        }

        //Animation
        anim.SetFloat("horizontalMove", rb.velocity.x);
        anim.SetFloat("verticalMove", rb.velocity.y);
    }

    private void Attack()
    {
        if (attackCooldown <= 0)
        {
            if (atAttackRange)
            {
                isAttacking = true;
                attackCooldown = initialAttackCooldown;
            }
        }
        else
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown <= 0)
            {
                attackCooldown = 0;
            }
        }

        // Animation
        anim.SetBool("isAttacking", isAttacking);
    }

    public void GetAnimationEvent(string eventMessage)
    {
        if (eventMessage.Equals("AttackEnded"))
        {
            isAttacking = false;
            if (Vector2.Distance(player.transform.position, transform.position) <= attackRadius)
            {
                player.GetComponent<Player>().TakeDamage(attackDamage);
            }
        }
    }

    public void Orientation()
    {
        float horizontalOrientation = player.transform.position.x - transform.position.x;
        float verticalOrientation = player.transform.position.y - transform.position.y;
        anim.SetFloat("verticalOrientation", verticalOrientation);
        anim.SetFloat("horizontalOrientation", horizontalOrientation);

    }
}
