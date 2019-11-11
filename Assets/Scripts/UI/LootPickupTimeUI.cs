using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootPickupTimeUI : MonoBehaviour
{

    public GameObject loot;
    private Image imageComponent;
    private float timeLeft;
    public bool showTime;
    public Sprite[] bars;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        showTime = !loot.GetComponent<Loot>().isPickup && !loot.GetComponent<Loot>().isThrow;

        if (showTime)
        {
            timeLeft = loot.GetComponent<Loot>().GetTimeleftinPercentage();
            Debug.Log((int)Mathf.Floor(timeLeft *(bars.Length - 1)));
            imageComponent.sprite = bars[(int)Mathf.Floor(timeLeft * (bars.Length - 1))];
        }
        else
        {
        }
    }
}
