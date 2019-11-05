using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldownUI : MonoBehaviour
{

    private Text texte;
    private Player player;
    private float cooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        texte = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = player.GetDashCooldown();
        if (cooldown <= 0)
        {
            texte.text = "Dash !";
        }
        else
        {
            texte.text = string.Format("{0:N1}",cooldown);
        }
    }
}
