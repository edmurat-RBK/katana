﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShurikenBarUI : MonoBehaviour
{
    //private Image imageComponant;
    private Player player;
    public GameObject firstShuriken;
    public GameObject secondShuriken;
    public GameObject thirdShuriken;
    public Sprite emptyShurikenSprite;
    public Sprite loadedShurikenSprite;
    //public Sprite[] bars;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(player.shurikenLoaded)
        {
            case 0:
                firstShuriken.GetComponent<Image>().sprite = emptyShurikenSprite;
                secondShuriken.GetComponent<Image>().sprite = emptyShurikenSprite;
                thirdShuriken.GetComponent<Image>().sprite = emptyShurikenSprite;
                break;
            case 1:
                firstShuriken.GetComponent<Image>().sprite = loadedShurikenSprite;
                break;
            case 2:
                secondShuriken.GetComponent<Image>().sprite = loadedShurikenSprite;
                break;
            case 3:
                thirdShuriken.GetComponent<Image>().sprite = loadedShurikenSprite;
                break;
        }
    }
}
