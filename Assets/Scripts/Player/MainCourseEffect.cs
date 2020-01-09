using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCourseEffect : MonoBehaviour
{
    // effet des plats 
    public float Plat1HealthCd;
    public float Plat2HealthCd;
    public float Plat3HealthCd;

    private Player player;
    private GameManager gameManager;
    private float CurrentHealth;

    public Scene SandboxScene;
    private bool isInHub;

    // Start is called before the first frame update
    void Start()
    {
        isInHub = true;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        CurrentHealth = player.health;

        Debug.Log("Allo");
        switch (gameManager.PlatSelect)
        {
            case GameManager.Plat.Plat1:
                StartCoroutine(RegenPlat1());
                break;

            case GameManager.Plat.Plat2:
                StartCoroutine(RegenPlat2());
                break;

            case GameManager.Plat.Plat3:
                StartCoroutine(RegenPlat3());
                break;
            default:
                //reinitialiser
                Debug.Log("Je passe dans default2");

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "SandboxScene")
        {
            isInHub = true;

        }
        else
        {
            isInHub = false;
        }
    }


    IEnumerator RegenPlat1()
    {
        while (isInHub)
        {
            yield return new WaitForSeconds(Plat1HealthCd);
            if (player.health <= 9)
            {
                player.health += 1;
            }
        }
    }
    IEnumerator RegenPlat2()
    {
        while (isInHub)
        {
            yield return new WaitForSeconds(Plat2HealthCd);
            if (player.health <= 9)
            {
                player.health += 1;
            }
        }
    }
    IEnumerator RegenPlat3()
    {
        while (isInHub)
        {
            yield return new WaitForSeconds(Plat3HealthCd);
            if (player.health <= 9)
            {
                player.health += 1;
            }
        }
    }
}
