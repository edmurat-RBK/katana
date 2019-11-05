using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Component
    private Rigidbody2D rb;
    private Animator anim;

    // Move
    public float speed = 1f;
    // Dash
    public float dashSpeed = 1.5f;
    private float dashTime;
    public float initialDashTime = 1f;
    private float dashCooldown;
    public float initialDashCooldown = 2f;
    private bool isDashing = false;
    // Melee Attack
    public float attackMeleeDamage = 2f;
    public float attackMeleeRange = 0.5f;
    public float attackMeleeRadius = 1f;
    private Transform attackMeleePosition;
    private GameObject attackMeleeLandmark;
    public LayerMask layerMask;
    private float attackMeleeCooldown;
    public float initialAttackMeleeCooldown = 0.15f;
    private bool isMeleeAttacking = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        dashTime = initialDashTime;

        attackMeleeLandmark = GameObject.Find("Attack Melee Landmark");
    }

    void Update()
    {
        if(!isMeleeAttacking)
        {
            Move();
        }

        if (!isMeleeAttacking)
        {
            Dash();
        }

        if (!isDashing)
        {
            MeleeAttack();
        }
    }



    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputHorizontal, inputVertical, 0f);
        rb.velocity = new Vector2(movement.x, movement.y).normalized * speed;

        // Animation
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("horizontalMovement", rb.velocity.x);
            anim.SetFloat("verticalMovement", rb.velocity.y);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void Dash()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");
        float inputDash = Input.GetAxis("Dash");

        if(!isDashing)
        {
            if(dashCooldown <= 0)
            {
                if(inputDash == 1f)
                {
                    isDashing = true;
                }
            }
            else
            {
                dashCooldown -= Time.deltaTime;
                if(dashCooldown <= 0)
                {
                    dashCooldown = 0;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                isDashing = false;
                dashTime = initialDashTime;
                dashCooldown = initialDashCooldown;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;
                rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * dashSpeed;
            }
        }

        // Animation
        if (isDashing)
        {
            anim.SetBool("isDashing", true);
            anim.SetFloat("horizontalMovement", rb.velocity.x);
            anim.SetFloat("verticalMovement", rb.velocity.y);
        }
        else
        {
            anim.SetBool("isDashing", false);
        }
    }

    private void MeleeAttack()
    {
        float inputMelee = Input.GetAxis("Melee Attack");

        if (!isMeleeAttacking)
        {
            if(attackMeleeCooldown <= 0)
            {
                if(inputMelee == 1f)
                {
                    isMeleeAttacking = true;

                    /*
                    if (Input.GetAxis("Horizontal") >= Math.Sqrt(2) / 2)
                    {
                        attackMeleePosition.position = attackMeleeLandmark.transform.position + new Vector3(attackMeleeRange, 0, 0);
                    }
                    else if (Input.GetAxis("Horizontal") <= -Math.Sqrt(2) / 2)
                    {
                        attackMeleePosition.position = attackMeleeLandmark.transform.position + new Vector3(-attackMeleeRange, 0, 0);
                    }
                    else if (Input.GetAxis("Vertical") >= Math.Sqrt(2) / 2)
                    {
                        attackMeleePosition.position = attackMeleeLandmark.transform.position + new Vector3(0, attackMeleeRange, 0);
                    }
                    else if (Input.GetAxis("Vertical") <= -Math.Sqrt(2) / 2)
                    {
                        attackMeleePosition.position = attackMeleeLandmark.transform.position + new Vector3(0, -attackMeleeRange, 0);
                    }

                    Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackMeleePosition.position, attackMeleeRadius, layerMask);
                    for (int i = 0; i < enemiesHit.Length; i++)
                    {
                        enemiesHit[i].GetComponent<Enemy>().TakeDamage(attackMeleeDamage);
                    }
                    */
                }
            }
            else
            {
                attackMeleeCooldown -= Time.deltaTime;
                if(attackMeleeCooldown <= 0)
                {
                    attackMeleeCooldown = 0;
                }
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        // Animation
        if (isMeleeAttacking)
        {
            anim.SetBool("isMeleeAttacking", true);
        }
        else
        {
            anim.SetBool("isMeleeAttacking", false);
        }
    }

    public void GetAnimationEvent(string eventMessage)
    {
        if(eventMessage.Equals("MeleeAttackEnded"))
        {
            isMeleeAttacking = false;
            attackMeleeCooldown = initialAttackMeleeCooldown;
        }
    }

    /*
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackMeleePosition.position, attackMeleeRadius);
    }
    */

    // Used by UI - Exist only for tests
    public float GetDashCooldown()
    {
        return dashCooldown;
    }
}
