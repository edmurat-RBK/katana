using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Enemy : MonoBehaviour
{
    // Component
    protected Rigidbody2D rb;
    protected Animator anim;
    protected GameObject player;
    public GameObject cameraShakeController;

    // Health
    public float maximumHealth;
    protected float health;
    [HideInInspector] public bool isDead = false;
    // Movement
    public float baseSpeed;
    protected float speedModifier = 1f;
    public float realSpeed;
    Vector3 mLastPosition;

    // Attack
    public float attackDamage;
    public float attackModifier = 1f;
    protected float attackCooldown;
    public float initialAttackCooldown;
    public bool isAttacking = false;

    // Loot
    public GameObject lootPrefab;
    public float lootChance;


    public void OnStart()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        cameraShakeController = GameObject.FindGameObjectWithTag("CameraController");
        health = maximumHealth;
    }

    public void OnUpdate()
    {
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
            if (attackCooldown < 0)
            {
                attackCooldown = 0;
            }
        }

        if (health <= 0)
        {
            anim.SetBool("isDead", true);
            Time.timeScale = 1f;
        }

        if (isDead)
        {
            Loot();
            Death();
        }
    }

    public void DealDamage()
    {
        player.GetComponent<Player>().health -= attackDamage;
    }

    public void TakeDamage(float damageDealtByOther)
    {
        if (health > 0)
        {
            health -= damageDealtByOther;
            anim.SetBool("isDamage", true);
            attackCooldown = initialAttackCooldown;
            Time.timeScale = 0.8f;
        }  
    }

    public void Loot()
    {
        float lootProbability = Random.Range(0f, 1f);
        if (lootChance >= lootProbability)
        {
            Instantiate(lootPrefab, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.identity);
        }
    }

    public void OnDeathAnimation()
    {
        isDead = true;
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

    public void HitEnded()
    {
        anim.SetBool("isDamage", false);
        Time.timeScale = 1f;
    }
}
