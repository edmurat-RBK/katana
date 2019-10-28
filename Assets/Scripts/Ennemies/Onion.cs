using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onion : MonoBehaviour
{
    enum Direction
    {
        UP = 0,
        UP_RIGHT = 1,
        RIGHT = 2,
        DOWN_RIGHT = 3,
        DOWN = 4,
        DOWN_LEFT = 5,
        LEFT = 6,
        UP_LEFT = 7
    }

    public float speed = 1f;
    private Direction direction;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        direction = (Direction)Random.Range(0, 7);
        StartCoroutine("ChangeDirection");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,0);

        switch (direction)
        {
            case Direction.UP:
                rb.velocity += new Vector2(0, -1).normalized * speed;
                break;
            case Direction.UP_RIGHT:
                rb.velocity += new Vector2(1, -1).normalized * speed;
                break;
            case Direction.RIGHT:
                rb.velocity += new Vector2(1, 0).normalized * speed;
                break;
            case Direction.DOWN_RIGHT:
                rb.velocity += new Vector2(1, 1).normalized * speed;
                break;
            case Direction.DOWN:
                rb.velocity += new Vector2(0, 1).normalized * speed;
                break;
            case Direction.DOWN_LEFT:
                rb.velocity += new Vector2(-1, 1).normalized * speed;
                break;
            case Direction.LEFT:
                rb.velocity += new Vector2(-1, 0).normalized * speed;
                break;
            case Direction.UP_LEFT:
                rb.velocity += new Vector2(-1, -1).normalized * speed;
                break;
        }

        // Animations
        anim.SetFloat("horizontalMove", rb.velocity.x);
        anim.SetFloat("verticalMove", rb.velocity.y);
    }

    private IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(Random.Range(1f, 6f));
        direction = (Direction)Random.Range(0, 7);
        StartCoroutine("ChangeDirection");
    }
}
