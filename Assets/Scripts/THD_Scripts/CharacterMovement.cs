using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class CharacterMovement : MonoBehaviour
{
    //Player speed related variables
    public float speed = 1f;

    //Player dash related variables
    public Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float idashTime;
    private int direction;
    [HideInInspector] public bool isDashing;
    public float iDashCooldown;
    float dashCooldown;

    //Player related variables
    public int health = 10;

    //Player animation
    public Animator animator; 

 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = idashTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            DashHandler();
            CharacterMove();
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //DashHandler method takes care of the player's dash
    void DashHandler()
    {
        float dashButton = Input.GetAxis("Dash");

        
            if (dashTime <= 0)
            {
                rb.velocity = Vector3.zero;
                isDashing = false;
            }

            if (dashButton == 1 && dashTime >= 0)//when the button is pressed the player dashes    
            {
                dashTime--;
                rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * dashSpeed;
                isDashing = true;
            }

            if (dashButton == 0)
            {
                dashTime = idashTime;
            }
    }

    //CharacterMove method takes care of the players movement
    void CharacterMove()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f); //This vector takes input from a joystick. It allows the player to move in every direction on a 2D plane
        rb.velocity = new Vector2(movement.x, movement.y).normalized * speed;
        //transform.position += movement.normalized * Time.deltaTime * speed; //The player position is updated, it depends on the movement vector and the speed value.

        animator.SetFloat("VerticalMove", movement.y * 100);
        animator.SetFloat("HorizontalMove", movement.x * 100);
    }




    public void PlayerTakeDamage()
    {
        health -= 1;
        Debug.Log(health);
    }
}

