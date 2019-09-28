using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSliceAttack : MonoBehaviour
{
    float timeInBtwAttack;
    public float iTimeInBtwAttack;

    public Transform attackPosition;
    public float attackRange;
    public LayerMask whatIsEnemy;
    public int Playerdamage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
