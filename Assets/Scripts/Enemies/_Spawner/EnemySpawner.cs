using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ActivateSpawn()
    {
        anim.SetBool("Spawn", true);
        Instantiate(enemy, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }

    public void GetAnimationEvent(string messageEvent)
    {
        if(messageEvent.Equals("ApparitionEnded"))
        {
            anim.SetBool("Spawn", false);
        }
    }
}
