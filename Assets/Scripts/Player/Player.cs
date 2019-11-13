using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // Components
    private Rigidbody2D rb;
    private Animator anim;

    // Health
    public float maximumHealth = 10f;
    [HideInInspector] public float health;
    private bool isAlive = true;
    //private bool isTakingDamage;
    // Move
    public float speed = 1f;
    public float speedModifier = 1f;
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
    public GameObject attackMeleeMarker;
    public LayerMask enemyLayerMask;
    private float attackMeleeCooldown;
    public float initialAttackMeleeCooldown = 0.10f;
    private bool isMeleeAttacking = false;
    // Range Attack
    public GameObject projectilePrefab;
    public int projectileCount = 3;
    private float attackRangeCooldown;
    public float initialAttackRangeCooldown = 4f;
    private bool isRangeAttacking = false;
    // Hold
    public GameObject itemHold;
    public Collider2D[] itemPickupable;
    public LayerMask lootLayerMask;
    [HideInInspector] public bool isHolding = false;
    public float throwForce = 20f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        health = maximumHealth;
        dashTime = initialDashTime;
    }

    void Update()
    {
        TestHealthModifier();

        if(isAlive)
        {
            Statistics();

            if (!isMeleeAttacking)
            {
                Move();
            }

            if (!isMeleeAttacking)
            {
                Dash();
            }

            if (!isDashing && !isHolding)
            {
                MeleeAttack();
            }
            
            if (!isMeleeAttacking && !isDashing)
            {
                RangeAttack();
            }

            if(!isMeleeAttacking && !isDashing)
            {
                Pickup();
            }

            if(isHolding)
            {
                Consume();
                Throw();
            }

            anim.SetBool("isDead", false);
        }
        else
        {
            anim.SetBool("isDead", true);
        }

        /*if(isTakingDamage==true)
        {
            anim.SetBool("isDamage", true);
            new WaitForSeconds(0.2f);
            isTakingDamage = false;

        }*/
        
    }



    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputHorizontal, inputVertical, 0f);
        rb.velocity = new Vector2(movement.x, movement.y).normalized * (speed * speedModifier);

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
        bool inputDash = Input.GetButtonDown("Dash");

        if(!isDashing)
        {
            if(dashCooldown <= 0)
            {
                if(inputDash && (rb.velocity.x != 0 || rb.velocity.y != 0))
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
        }
        else
        {
            anim.SetBool("isDashing", false);
        }
    }

    private void MeleeAttack()
    {
        bool inputMelee = Input.GetButtonDown("MeleeAttack");
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (!isMeleeAttacking)
        {
            // Check joystick X an Y position
            if (inputHorizontal >= Math.Sqrt(2) / 2)
            {
                attackMeleeMarker.transform.position = gameObject.transform.position + new Vector3(attackMeleeRange + 0.5f, 0.5f, 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("horizontalDirection", 1f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("verticalDirection", 0f);
            }
            else if (inputHorizontal <= -Math.Sqrt(2) / 2)
            {
                attackMeleeMarker.transform.position = gameObject.transform.position + new Vector3(-attackMeleeRange - 0.5f, 0.5f, 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("horizontalDirection", -1f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("verticalDirection", 0f);
            }
            else if (inputVertical >= Math.Sqrt(2) / 2)
            {
                attackMeleeMarker.transform.position = gameObject.transform.position + new Vector3(0f, attackMeleeRange + 0.5f, 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("horizontalDirection", 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("verticalDirection", 1f);
            }
            else if (inputVertical <= -Math.Sqrt(2) / 2)
            {
                attackMeleeMarker.transform.position = gameObject.transform.position + new Vector3(0f, -attackMeleeRange, 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("horizontalDirection", 0f);
                attackMeleeMarker.GetComponent<Animator>().SetFloat("verticalDirection", -1);
            }

            // If cooldown up
            if (attackMeleeCooldown <= 0)
            {
                if(inputMelee)
                {
                    isMeleeAttacking = true;

                    Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackMeleeMarker.transform.position, attackMeleeRadius, enemyLayerMask);
                    for (int i = 0; i < enemiesHit.Length; i++)
                    {
                        enemiesHit[i].GetComponent<NewEnemy>().TakeDamage(attackMeleeDamage);
                    }

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
            attackMeleeMarker.GetComponent<Animator>().SetBool("isMeleeAttacking", true);
        }
        else
        {
            anim.SetBool("isMeleeAttacking", false);
            attackMeleeMarker.GetComponent<Animator>().SetBool("isMeleeAttacking", false);
        }
    }

    private void RangeAttack()
    {
        bool inputRange = Input.GetButtonDown("RangeAttack");
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (attackRangeCooldown <= 0)
        {
            if(inputRange)
            {
                Debug.Log("SHURIKEN");
                if (Input.GetAxis("Horizontal") >= Math.Sqrt(2) / 2)
                {
                    GameObject instance = Instantiate(projectilePrefab, new Vector3(transform.position.x + 0.5f, transform.position.y, 0f), Quaternion.identity);
                    instance.GetComponent<Shuriken>().direction = Shuriken.Direction.EAST;
                }
                else if (Input.GetAxis("Horizontal") <= -Math.Sqrt(2) / 2)
                {
                    GameObject instance = Instantiate(projectilePrefab, new Vector3(transform.position.x - 0.5f, transform.position.y, 0f), Quaternion.identity);
                    instance.GetComponent<Shuriken>().direction = Shuriken.Direction.WEST;
                }
                else if (Input.GetAxis("Vertical") >= Math.Sqrt(2) / 2)
                {
                    GameObject instance = Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, 0f), Quaternion.identity);
                    instance.GetComponent<Shuriken>().direction = Shuriken.Direction.NORTH;
                }
                else if (Input.GetAxis("Vertical") <= -Math.Sqrt(2) / 2)
                {
                    GameObject instance = Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y - 0.5f, 0f), Quaternion.identity);
                    instance.GetComponent<Shuriken>().direction = Shuriken.Direction.SOUTH;
                }

                attackRangeCooldown = initialAttackRangeCooldown;
            }
        }
        else
        {
            attackRangeCooldown -= Time.deltaTime;
            if (attackRangeCooldown <= 0)
            {
                attackRangeCooldown = 0;
            }
        }
    }

    private void Pickup()
    {
        itemPickupable = Physics2D.OverlapCircleAll(transform.position, 1f, lootLayerMask);

        if (!isHolding)
        {
            if(itemPickupable.Length >= 1)
            {
                if(Input.GetButtonDown("Pick"))
                {
                    isHolding = true;
                    anim.SetBool("isHolding", true);
                    itemHold = itemPickupable[0].gameObject;
                    itemHold.GetComponent<Loot>().isPickup = true;
                }
            }
        }
        else
        {
            itemHold.transform.position = new Vector3(transform.position.x, transform.position.y + 1.25f, 0f);
            speedModifier = 0.75f;
        }
    }

    private void Throw()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Throw"))
        {
            isHolding = false;
            anim.SetBool("isHolding", false);
            itemHold.GetComponent<Loot>().isThrow = true;
            itemHold.GetComponent<Loot>().isPickup = false;
            Vector2 force = new Vector2(inputHorizontal, inputVertical).normalized * throwForce;
            itemHold.GetComponent<Rigidbody2D>().AddForce(force,ForceMode2D.Impulse);
            speedModifier = 1f;
        }
    }

    private void Consume()
    {
        if (Input.GetButtonDown("Consume"))
        {
            switch (itemHold.GetComponent<Loot>().item)
            {
                case Item.ONION:
                    // Onion effet 
                    break;
                default:
                    //Do nothing
                    break;
            }

            isHolding = false;
            anim.SetBool("isHolding", false);
            speedModifier = 1f;
            Destroy(itemHold);
        }

    }

    private void Statistics()
    {
        if(health <= 0)
        {
            isAlive = false;
            health = 0;
        }

    }

    public void TakeDamage(float damage)
    {
        if(health > 0)
        {
            health -= damage;
            if(health <= 0)
            {
                health = 0;
            }
        }
        //isTakingDamage = true;
    }

    public void GetAnimationEvent(string eventMessage)
    {
        if(eventMessage.Equals("MeleeAttackEnded"))
        {
            isMeleeAttacking = false;
            attackMeleeCooldown = initialAttackMeleeCooldown;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackMeleeMarker.transform.position, attackMeleeRadius);
    }

    // UI methods
    public float GetCooldownInPercentage()
    {
        return 1 - (dashCooldown / initialDashCooldown);
    }

    private void TestHealthModifier()
    {
        if(Input.GetKeyDown(KeyCode.P) && health < 10)
        {
            health++;
            anim.SetBool("isDead", false);
        }

        if (Input.GetKeyDown(KeyCode.M) && health > 0)
        {
            health--;

            // Animation (death)
            if (health <= 0)
            {
                anim.SetBool("isDead", true);
            }
            else
            {
                anim.SetBool("isDead", false);
            }
        }
    }

    public int GetHealth()
    {
        return (int)Mathf.Ceil(health);
    }
}
