using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarutofuOriginal : EnemyBehaviour
{
    Transform target;
    public float stoppingDistance;
    public GameObject narutofuClonePrefab;
    float SpawnCooldown;
    public float iSpawnCooldown;
    public float spawnRange;
    bool isAttacking;
    private float lootChance;
    public float lootPercentage;
    //ajout arthur
    private SpriteRenderer SprRender;


    // Start is called before the first frame update
    void Start()
    {
        lootChance = Random.Range(0f, 1f);
        target = GameObject.Find("Player").GetComponent<Transform>();
        SpawnCooldown = iSpawnCooldown;
        isAttacking = false;
        //ajout arthur
        SprRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        NarutofuMovement();
        narutofuSpawn();

    }
    void NarutofuMovement()
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
    void narutofuSpawn()
    {

        Debug.Log("readytospawn");
        if (Vector3.Distance(target.position, transform.position) <= spawnRange)
        {
            if (SpawnCooldown <= 0 && !isAttacking)//Cooldown du spawn
            {
                Debug.Log("kagebunshinnojutsu");
                isAttacking = true;
                GameObject narutofuClone = Instantiate(narutofuClonePrefab, transform.position, transform.rotation);

            }


            else if (!isAttacking)
            {
                SpawnCooldown--;

            }


        }
        else
        {
            isAttacking = false;
        }
    }
}
