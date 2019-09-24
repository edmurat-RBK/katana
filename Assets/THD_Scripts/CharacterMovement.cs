using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb; 

    //Player speed related variables
    public float speed = 1f;

    //Player dash related variables
    public float dashSpeed;
    private float dashTime;
    public float idashTime;
    private int direction;
    [HideInInspector] public bool isDashing;

 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = idashTime;
    }

    // Update is called once per frame
    void Update()
    {
        DashHandler();
        CharacterMove();
    }

    void DashHandler()
    {
        if (dashTime <= 0)
        {
            dashTime = idashTime;
            rb.velocity = Vector2.zero;
            isDashing = false;
        }
        else
        {
            dashTime -= Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.LeftControl))
                
            {               
                if (Input.GetAxis("Horizontal") == 1 && Input.GetAxis("Vertical") == 1)//Dash haut droite
                {
                    rb.velocity =  Vector2.one * dashSpeed;
                    isDashing = true;
                }

                else if (Input.GetAxis("Horizontal") == -1 && Input.GetAxis("Vertical") == 1)//Dash haut gauche
                {
                    rb.velocity = (Vector2.up +Vector2.left) * dashSpeed;
                    isDashing = true;
                }
                else if (Input.GetAxis("Horizontal") == 1 && Input.GetAxis("Vertical") == -1)//Dash bas droite
                {
                    rb.velocity = (Vector2.down + Vector2.right) * dashSpeed;
                    isDashing = true;
                }
                else if (Input.GetAxis("Horizontal") == -1 && Input.GetAxis("Vertical") == -1)//Dash bas gauche
                {
                    rb.velocity = (Vector2.down + Vector2.left) * dashSpeed;
                    isDashing = true;
                }
                else if (Input.GetAxis("Horizontal") == 1) //Dash droit
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    isDashing = true;
                }
                else if (Input.GetAxis("Horizontal") == -1)//Dash gauche
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    isDashing = true;
                }
                else if (Input.GetAxis("Vertical") == 1)//Dash haut
                {
                    rb.velocity = Vector2.up * dashSpeed;
                    isDashing = true;
                }
                else if (Input.GetAxis("Vertical") == -1)//Dash bas
                {
                    rb.velocity = Vector2.down * dashSpeed;
                    isDashing = true;
                }

            }
        }
    }

    void CharacterMove()
    {
        Transform target = GetComponent<PlayerSliceAttack>().attackPosition;
        float targetDist = Vector3.Distance(transform.position, target.position);

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f); 
        transform.position += movement * Time.deltaTime * speed;

        if (targetDist <= 0.1)
        {           
            target.position += movement.normalized;
        }
        else
        {
            target.position = transform.position;
        }
     
    }



}
