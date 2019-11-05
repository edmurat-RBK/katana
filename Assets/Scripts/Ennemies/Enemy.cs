using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int          health;
    public float        speed;
    public float        attackDamage;
    public bool         isAttacking;
    private float       lootChance; //proba de drop init au spawn du mob
    public float        lootPercentage; // proba de drop attaché à un type d'ennemi
    public GameObject   loot;
    public GameObject   target;

    public void TakeDamage(float damage)
    {
        Debug.Log("Hit " + gameObject.name);
    }

    public void Loot()
    {
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

    private void Update()
    {
        OnDeath();
    }

    private void Start()
    {
        lootChance = Random.Range(0f, 1f);
    }
}
