using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatsBuffsScripts : MonoBehaviour
{

    public GameObject shuriken = GameObject.Find("Shuriken");

    private float initMeleeDmg;
    private float CurrentMeleeDmg;
    private float initRangeDmg;
    private float CurrentRangeDmg;
    private float InitSpeed;
    private float Currentspeed;
    private float OriginalDashCD;
    private float CurrentDashCD;
    private float CurrentHealth;
    // effets des entrées
    public float Starter1MeleeAttackbonus;
    public float Starter2RangeAttackbonus;
    public float Starter3RangeAttackbonus;
    public float Starter3MeleeAttackbonus;
    // effet des plats 
    public float Plat1HealthCd;
    public float Plat2HealthCd;
    public float Plat3HealthCd;
    // effet des desserts
    public float dessert1speedbonus;
    public float dessert2speedbonus;
    public float dessert2dashbonus;
    public float dessert3speedbonus;
    public float dessert3dashbonus;


    void Start()
    {
        initMeleeDmg = gameObject.GetComponent<Player>().attackMeleeDamage;
        initRangeDmg = shuriken.GetComponent<Shuriken>().attackDamage;
        InitSpeed = gameObject.GetComponent<Player>().speed;
        OriginalDashCD = gameObject.GetComponent<Player>().initialDashCooldown;
    }
    // Update is called once per frame
    void Update()
    {
        CurrentHealth = gameObject.GetComponent<Player>().health;
        //EatEffects();
    }
    private void EatEffects()
    {
        /*
        switch ()
        {

            case starter1:
                CurrentMeleeDmg = initMeleeDmg + Starter1MeleeAttackbonus;
                gameObject.GetComponent<Player>().attackMeleeDamage = CurrentMeleeDmg;
                break;


            case starter2:
                CurrentMeleeDmg = initRangeDmg + Starter2RangeAttackbonus;
                shuriken.GetComponent<Shuriken>().attackDamage = CurrentRangeDmg;
                break;


            case starter3:
                CurrentMeleeDmg = initMeleeDmg + Starter3MeleeAttackbonus;
                gameObject.GetComponent<Player>().attackMeleeDamage = CurrentMeleeDmg;
                CurrentMeleeDmg = initRangeDmg + Starter3RangeAttackbonus;
                shuriken.GetComponent<Shuriken>().attackDamage = CurrentRangeDmg;
                break;
            default:
                //reinitialiser
                gameObject.GetComponent<Player>().attackMeleeDamage = initMeleeDmg;
                shuriken.GetComponent<Shuriken>().attackDamage = initRangeDmg;
                gameObject.GetComponent<Player>().speed = InitSpeed;
                gameObject.GetComponent<Player>().initialDashCooldown = OriginalDashCD;
                break;
        }
        switch ()
        {
            case Plat1:
                StartCoroutine(RegenPlat1());
                break;


            case Plat2:
                StartCoroutine(RegenPlat2());
                break;


            case Plat3:
                StartCoroutine(RegenPlat3());
                break;
            default:
                //reinitialiser
                gameObject.GetComponent<Player>().attackMeleeDamage = initMeleeDmg;
                shuriken.GetComponent<Shuriken>().attackDamage = initRangeDmg;
                gameObject.GetComponent<Player>().speed = InitSpeed;
                gameObject.GetComponent<Player>().initialDashCooldown = OriginalDashCD;
                break;
        }
        switch ()
        {
            case Dessert1:
                Currentspeed =  InitSpeed + dessert1speedbonus;
                gameObject.GetComponent<Player>().speed = Currentspeed;
                break;


            case Dessert2:
                Currentspeed = InitSpeed + dessert2speedbonus;
                gameObject.GetComponent<Player>().speed = Currentspeed;
                CurrentDashCD = OriginalDashCD - dessert2dashbonus;
                gameObject.GetComponent<Player>().initialDashCooldown = CurrentDashCD;
                break;


            case Dessert3:
                Currentspeed = InitSpeed + dessert3speedbonus;
                gameObject.GetComponent<Player>().speed = Currentspeed;
                CurrentDashCD = OriginalDashCD - dessert3dashbonus;
                gameObject.GetComponent<Player>().initialDashCooldown = CurrentDashCD;
                break;


            default:
                //reinitialiser
                gameObject.GetComponent<Player>().attackMeleeDamage = initMeleeDmg;
                shuriken.GetComponent<Shuriken>().attackDamage = initRangeDmg;
                gameObject.GetComponent<Player>().speed = InitSpeed;
                gameObject.GetComponent<Player>().initialDashCooldown = OriginalDashCD;
                break;
        }
        */
    }

    IEnumerator RegenPlat1()
    {

        yield return new WaitForSeconds(Plat1HealthCd);
        if (CurrentHealth <= 9)
        {
            gameObject.GetComponent<Player>().health = CurrentHealth+1;
        }
        StartCoroutine(RegenPlat1());
    }
    IEnumerator RegenPlat2()
    {

        yield return new WaitForSeconds(Plat2HealthCd);
        if (CurrentHealth <= 9)
        {
            gameObject.GetComponent<Player>().health = CurrentHealth + 1;
        }
        StartCoroutine(RegenPlat2());
    }
    IEnumerator RegenPlat3()
    {

        yield return new WaitForSeconds(Plat3HealthCd);
        if (CurrentHealth <= 9)
        {
            gameObject.GetComponent<Player>().health = CurrentHealth + 1;
        }
        StartCoroutine(RegenPlat3());
    }
}
