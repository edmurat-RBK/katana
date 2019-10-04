using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health;
    public float speed;
    public float attackDamage; 

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
