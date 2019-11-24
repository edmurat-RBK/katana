using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float maximumLifetime = 10f;
    private float lifetime;
    public float rotationSpeed = 0.01f;
    public float attackDamage = 0.5f;
    public int shurikenDamage; 

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationSpeed, 0f);

        lifetime += Time.deltaTime;
        if(lifetime >= maximumLifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(shurikenDamage);
            collision.gameObject.GetComponent<Animator>().SetBool("isDamage", true);
        }
        
        if(!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
