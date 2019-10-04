using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{

    public GameObject objectToLoot;
    public float lootPercentage;
    public int numberToLoot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int health = GetComponent<EnemyBehaviour>.health;  

        if (health <= 0)
        {
            if (Random.Range(0.0f,1.0f) <= lootPercentage)
            {
                Debug.Log("wtf");
                for (int i = 0; i < numberToLoot; i++)
                {
                    Instantiate(objectToLoot, new Vector3(Random.Range(0.0f, 0.3f), Random.Range(0.0f, 0.3f), 0), Quaternion.identity);
                }
            }
        }
    }
}
