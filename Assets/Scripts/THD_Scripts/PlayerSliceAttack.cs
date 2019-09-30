using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerSliceAttack : MonoBehaviour
{
    float timeInBtwAttack;
    public float iTimeInBtwAttack;

    public Transform attackPosition;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int Playerdamage;
    double sqrt2by2 = (Math.Sqrt(2) / 2);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttackTarget();
        if (timeInBtwAttack <= 0)
        {
            if (Input.GetAxis("Attack") == 1 && CanAttack() == true)
            {
                Collider2D[] ennemiesToDamage = Physics2D.OverlapCircleAll(attackPosition.position, attackRange, whatIsEnemy);
                for (int i = 0; i < ennemiesToDamage.Length; i++)
                {
                    ennemiesToDamage[i].GetComponent<EnemyBehaviour>().TakeDamage(Playerdamage);
                }
                timeInBtwAttack = iTimeInBtwAttack;
            }
        }
        else if(Input.GetAxis("Attack") == 0)
        {
            timeInBtwAttack -= Time.deltaTime;
        }
        
    }
    //AttackTarget method updates the direction where the player attacks when he presses a button on the gamepad
    void AttackTarget()
    {

        Transform target = GameObject.Find("IattackPosition").transform; 

        if (Input.GetAxis("Horizontal") >= sqrt2by2)
        {
            attackPosition.position = target.position + new Vector3(0.5f, 0, 0);
        }
        else if (Input.GetAxis("Horizontal") <= -sqrt2by2)
        {
            attackPosition.position = target.position + new Vector3(-0.5f, 0, 0);
        }
        else if (Input.GetAxis("Vertical") >= sqrt2by2)
        {
            attackPosition.position= target.position + new Vector3(0, 0.5f, 0);
        }
        else if (Input.GetAxis("Vertical") <= -sqrt2by2)
        {
            attackPosition.position = target.position + new Vector3(0, -0.5f, 0);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosition.position, attackRange);
    }

    bool CanAttack()
    {
        if (GetComponent<CharacterMovement>().isDashing == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

  
}
