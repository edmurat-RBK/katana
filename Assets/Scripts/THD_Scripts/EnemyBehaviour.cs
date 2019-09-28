using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health;
    public float speed;
    public float attackDamage; 


    void Update()
    {
        EnemyMovement();
        if (health <=0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        health -= damage;
        Debug.Log("OUCH");
    }
    public void EnemyMovement()
    {
        Vector3 movement = new Vector3(-1f, 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;
    }
}
