using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;
    public float speed = 5f;
    public int damage = 10;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Implement enemy movement logic here
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Implement collision logic (e.g., check if collided with player, apply damage)
    }

    // Other methods for attack logic, taking damage, etc.
}
