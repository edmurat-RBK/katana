using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class narutoCloneBehaviour : EnemyBehaviour
{
    Transform target;
    private float lootChance;
    public float lootPercentage;
    public float timetodeath =100;
    public float triggerExplosionDistance;
    public float tailleExplosion;
    bool triggered = false;
    public float cooldownSuicide;
    CircleCollider2D explosion;
    //ajout arthur
    private SpriteRenderer SprRender;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        SprRender = SprRender = GetComponent<SpriteRenderer>();
        explosion = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        NarutofuCloneMovement();
        NarutofuCloneExplosionTrigger();
    }
    private void FixedUpdate()
    {
        NarutofuCloneAging();
        NarutofuCloneExplosion();
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
        if (triggered == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
        }
    }
    void NarutofuCloneAging()
    {
        if (timetodeath >= 0 && triggered == false)
        {
            timetodeath-- ;
        }
        if (timetodeath == 0 || health <=0)
        {
            Destroy(gameObject);
            Debug.Log("time death");
        }
    }
    void NarutofuCloneExplosionTrigger()
    {
        if (Vector3.Distance(transform.position, target.position) < triggerExplosionDistance)
        {
            triggered = true;
            Debug.Log("trigger");
        }
    }
    void NarutofuCloneExplosion()
    {
        if (triggered == true && cooldownSuicide==0)
        {
            explosion.radius = tailleExplosion;
            Destroy(gameObject);
            Debug.Log("boom");
        }
        else if (triggered == true)
        {
            cooldownSuicide--;
            Debug.Log("tic tac");
        }
    }
}
