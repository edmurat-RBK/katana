using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    private GameObject[] props;
    private GameObject[] enemies;
    private GameObject player;
    private SpriteRenderer playerSpr;
    private SpriteRenderer spr;

    void Start()
    {
        props = GameObject.FindGameObjectsWithTag("Prop");
        
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpr = player.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        ManageLayers();
    }

    private void ManageLayers()
    {
        if (props.Length !=0)
        {
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].transform.position.y < player.transform.position.y)
                {
                    spr = props[i].GetComponent<SpriteRenderer>();
                    spr.sortingOrder = playerSpr.sortingOrder + 1;
                }
                else
                {
                    spr = props[i].GetComponent<SpriteRenderer>();
                    spr.sortingOrder = playerSpr.sortingOrder - 1;
                }
            }
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length != 0)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].transform.position.y < player.transform.position.y)
                {
                    spr = enemies[i].GetComponent<SpriteRenderer>();
                    spr.sortingOrder = playerSpr.sortingOrder + 1;
                }
                else
                {
                    spr = enemies[i].GetComponent<SpriteRenderer>();
                    spr.sortingOrder = playerSpr.sortingOrder - 1;
                }
            }
        }
        
    }

}
