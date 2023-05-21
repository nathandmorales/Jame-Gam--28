using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;
    public float speed = 5f;
    public int damage = 10;

    private Rigidbody2D rb;
    private bool isJumping = false;
    private float jumpForce = 5f;
    private Transform player;
 


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

private void Update()
{
    Vector2 direction = new Vector2(player.position.x - transform.position.x, 0f);
    direction.Normalize();

    rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);

    // Check if the player is higher than the enemy
    if (player.position.y > transform.position.y + 0.5f)
    {
        if (!isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    else
    {
        isJumping = false;
    }
}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Implement collision logic (e.g., check if collided with player, apply damage)
    }

    // Other methods for attack logic, taking damage, etc.
}
