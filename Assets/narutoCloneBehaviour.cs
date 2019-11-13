using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class narutoCloneBehaviour : EnemyBehaviour
{
    Transform target;
    private float lootChance;
    public float lootPercentage;
    //ajout arthur
    private SpriteRenderer SprRender;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        SprRender = SprRender = GetComponent<SpriteRenderer>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        NarutofuCloneMovement();
    }

    void NarutofuCloneMovement()
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
