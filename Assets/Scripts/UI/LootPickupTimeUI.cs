using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LootPickupTimeUI : MonoBehaviour
{

    public GameObject loot;
    private TextMeshProUGUI textComponent;
    private float timeLeft;
    public bool showTime;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        showTime = !loot.GetComponent<Loot>().isPickup && !loot.GetComponent<Loot>().isThrow;

        if (showTime)
        {
            timeLeft = loot.GetComponent<Loot>().pickupTime;
            textComponent.text = string.Format("{0:N1}", timeLeft);
        }
        else
        {
            textComponent.text = "";
        }
    }
}
