using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maximumHealth;
    [HideInInspector]
    public float health;
    public float speed;
    public float attackDamage;
    public bool isAttacking;
    private float lootChance; //proba de drop init au spawn du mob
    public float lootPercentage; // proba de drop attaché à un type d'ennemi
    public GameObject loot;
    [HideInInspector]
    public GameObject target;
    [HideInInspector]
    public Rigidbody2D rb;
    public float knockbackPower;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maximumHealth;
        target = GameObject.FindGameObjectWithTag("Player");       
    }
    
    //Don't use the Update method in this script, call this script's methods in the other realted scripts (onionbehaviour, watermelon behaviour...)
    public void TakeDamage(float damage)
    {
        health -= damage; 
    }

    public void Loot()
    {
        lootChance = Random.Range(0f, 1f);
        if (lootChance <= lootPercentage)
        {
            Instantiate(loot, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }

    public void OnDeath()
    {
        if (health <= 0)
        {
            // Death animation event
            Loot();
            Destroy(gameObject); //pour l'instant
        }
    }

    public void Knockback()
    {
        rb.AddForce(-rb.velocity.normalized * knockbackPower, ForceMode2D.Impulse);
    }

   
}
