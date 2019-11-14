using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject   enemyToSpawn;
    float               spawnRate;
    public float        ispawnRate;
    public int          numberToSpawn;
    private int         spawnUseCount;
    public int          spawnUseCountMax;
    private Animator    anim;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = ispawnRate;
        spawnUseCount = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnUseCount < spawnUseCountMax)//Nombre de fois max que le spawner va s'activer
        {
            if (spawnRate <= 0)
            {
                anim.SetBool("Spawn", true);
                for (int i = 0; i < numberToSpawn; i++) //Le spawner fait apparaitre x ennemis à la fois
                {
                    
                    Instantiate(enemyToSpawn, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                    spawnRate = ispawnRate;
                }
                spawnUseCount++;
            }
            else
            {
                anim.SetBool("Spawn", false);
                spawnRate--;
            }
        }
        else
        {
            anim.SetBool("Spawn", false);
        }
    }
}
