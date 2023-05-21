using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the player

    private Rigidbody2D rb;
    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Get horizontal input (left/right arrow keys, A/D keys, or joystick)

        if (moveX == 0)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);
        }

        Vector2 movement = new Vector2(moveX * speed, rb.velocity.y); // Create movement vector

        rb.velocity = movement; // Apply movement to the Rigidbody

        // If you want to flip the character sprite based on the direction of movement, uncomment the following code:
        /*
        if (moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        */
    }
}
