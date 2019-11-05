using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public float maximumHealth;
    public float health;
    public float knockbackResistance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        health = maximumHealth;
    }

    public void TakeDamage(float damage)
    {
        
    }

    public void TakeKnockback()
    {

    }
}
