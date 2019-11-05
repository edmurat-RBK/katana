using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashBarUI : MonoBehaviour
{
    private Image imageComponant;
    private Player player;
    private float cooldown;
    public Sprite[] bars;

    // Start is called before the first frame update
    void Start()
    {
        imageComponant = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = player.GetCooldownInPercentage();
        imageComponant.sprite = bars[(int)Mathf.Floor(cooldown * (bars.Length-1))];
    }
}
