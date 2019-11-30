using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float moveSpeed = 3f;
    Rigidbody2D rb;
    PlayerMovement target;
    Vector2 Direction;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<PlayerMovement>();
        Direction = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(Direction.x, Direction.y);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }
}
