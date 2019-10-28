using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputHorizontal, inputVertical, 0f);
        rb.velocity = new Vector2(movement.x, movement.y).normalized * speed;

        // Animation
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            anim.SetBool("isMoving", true);
            anim.SetFloat("horizontalMovement", rb.velocity.x);
            anim.SetFloat("verticalMovement", rb.velocity.y);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
