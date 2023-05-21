using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the player
    public float jumpForce = 5f;
    public Transform groundCheck;
    public Tilemap groundTilemap;
    public float groundCheckRadius = 0.2f;
    private bool isGrounded;
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
        isGrounded = CheckGrounded();

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

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

    private bool CheckGrounded()
    {
        // Convert the ground check position to tile coordinates
        Vector3Int tilePosition = groundTilemap.WorldToCell(groundCheck.position);

        // Check if there is a tile at the current position
        return groundTilemap.HasTile(tilePosition);
    }

    private void Jump()
    {
        // Apply vertical force to make the character jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
