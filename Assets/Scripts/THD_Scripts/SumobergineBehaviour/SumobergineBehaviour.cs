using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumobergineBehaviour : EnemyBehaviour
{
    Transform target;
    public float stoppingDistance;
    float attackCooldown;
    public float iattackCooldown;
    public float t;
    public float attackRange;
    bool isAttacking;
    private float lootChance;
    public float lootPercentage;
    public float sizeDiffShock;
    CircleCollider2D shockwave;
    public float speedShockWave;




    //ajout arthur
    private SpriteRenderer SprRender;

    // Start is called before the first frame update
    void Start()
    {
        shockwave = GetComponent<CircleCollider2D>();
        lootChance = Random.Range(0f, 1f);
        target = GameObject.Find("Player").GetComponent<Transform>();
        attackCooldown = iattackCooldown;
        isAttacking = false;

        //ajout arthur
        SprRender = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        EggplantAttack();
        EggplantMovement();


        //The Onion dies
        if (health <= 0)
        {
            OnionLoot();
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        if ((shockwave.radius < attackRange + sizeDiffShock) && (isAttacking == true))
        {
            shockwave.radius = shockwave.radius + speedShockWave;
            Debug.Log("current radius = " + shockwave.radius);

        }

        else
        {
            shockwave.radius = 0;
            Debug.Log("Reset done !");
        }
    }

    void EggplantMovement()
    {
        if (isAttacking == false)
        {
            if (Vector3.Distance(transform.position, target.position) > stoppingDistance)
            {

                if (Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed).x < 0)
                {
                    SprRender.flipX = true;
                    //GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    SprRender.flipX = false;
                    //GetComponent<SpriteRenderer>().flipX = false;
                }
                transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);


            }

        }


    }

    void EggplantAttack()
    {
        if (attackCooldown <= 0 && !isAttacking)//Cooldown de l'attaque de l'aubergine
        {
            Debug.Log("readytoattack");
            if (Vector3.Distance(target.position, transform.position) <= attackRange)
            {
                Debug.Log("a l'attaque");
                isAttacking = true;

            }
        }
        else if (isAttacking)
        {
            if (shockwave.radius < attackRange)
            {
                shockwave.radius += speedShockWave;
                //shockwave.radius = Mathf.Lerp(0, attackRange,t);
                //t += speedShockWave * Time.deltaTime;
                //Debug.Log("current radius = " + shockwave.radius);

            }
            else { isAttacking = false; }
            attackCooldown = iattackCooldown;
        }
        else if (!isAttacking)
        {
            attackCooldown--;

        }

    }

    void OnionLoot()
    {
        if (lootChance <= lootPercentage)
        {

            Debug.Log("wah le loot");
        }
    }



}
