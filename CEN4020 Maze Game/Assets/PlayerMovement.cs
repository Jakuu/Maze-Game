// Abbey Centers
// https://www.youtube.com/watch?v=whzomFgjT50


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is responsible for handling player movement using the keyboard arrow keys
public class PlayerMovement : MonoBehaviour
{
    // movement speed of the player
    public float moveSpeed = 5f;

    // the player object that this script is attached to must have a Rigidbody 2D component
    public Rigidbody2D rb;

    // used to handle x and y movements
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // get input from the user
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    // update the position of the player
    void FixedUpdate() 
    { 
        // movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
