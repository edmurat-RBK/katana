using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : MonoBehaviour
{
    // Component
    protected Rigidbody2D rb;
    protected Animator anim;
    protected GameObject player;
    // Health
    public float maximumHealth;
    protected float health;
    // Movement
    public float baseSpeed;
    protected float speedModifier = 1f;
    // Attack
    public float attackDamage;
    public float attackModifier = 1f;
    protected float attackCooldown;
    public float initialAttackCooldown;
    // Loot
    public GameObject lootPrefab;
    public float lootChance;

    public void OnStart()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");

        health = maximumHealth;
    }

    public void OnUpdate()
    {
        if(health <= 0)
        {
            Loot();
            Death();
        }

        if(attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            if(attackCooldown < 0)
            {
                attackCooldown = 0;
            }
        }
    }

    public void DealDamage()
    {
        player.GetComponent<Player>().health -= attackDamage;
        attackCooldown = initialAttackCooldown;
    }

    public void TakeDamage(float damageDealtByOther)
    {
        health -= damageDealtByOther;
    }

    public void Loot()
    {
        float lootProbability = Random.Range(0f, 1f);
        if(lootChance >= lootProbability)
        {
            Instantiate(lootPrefab, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void Orientation()
    {
        float horizontalOrientation = player.transform.position.x - transform.position.x;
        float verticalOrientation = player.transform.position.y - transform.position.y;
        anim.SetFloat("verticalOrientation", verticalOrientation);
        anim.SetFloat("horizontalOrientation", horizontalOrientation);
    }
}
