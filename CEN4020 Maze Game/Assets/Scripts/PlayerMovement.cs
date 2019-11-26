// Abbey Centers
// https://www.youtube.com/watch?v=whzomFgjT50

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private GameObject instObject;
    public GameObject spawn, hit;
    public float moveSpeed = 5f;
    public int health = 3;
    public Rigidbody2D rb;

    Vector2 movement;


    public GameObject tilemapGameObject;
    Tilemap tilemap;

   

    // Update is called once per frame
    void Update()
    {
        // input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() 
    { 
        // movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals ("Enemy"))
        {
            health = health - 1; //player loses 1 health
            if (health == 0)  //if die
            {
                instObject = (GameObject) Instantiate(hit, transform.position, transform.rotation); //create explosion temp object
                Destroy(instObject, 2f); //destroy temp explosion object
                this.transform.position = spawn.transform.position; //respawn
                //gameObject.SetActive(false);
                //Time.timeScale = 0f;   
                health = 3; //set health back to 3
            }
        }
    }

   

}
