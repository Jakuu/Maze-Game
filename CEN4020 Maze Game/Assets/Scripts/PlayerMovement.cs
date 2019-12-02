// Abbey Centers
// https://www.youtube.com/watch?v=whzomFgjT50

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject deadMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject canvasPause;

    public GameObject hit, spawn;
    private GameObject instObject;
    public float moveSpeed = 5f;
    public int health = 300;
    public Rigidbody2D rb;

    Vector2 movement;

    bool pause = false;

    private void Start()
    {
        health = 300;
    }


    // Update is called once per frame
    void Update()
    {
        if (pause == true)
        {
            deadMenu.SetActive(true);
            pauseMenu.SetActive(false);
            canvasPause.SetActive(true);
            PauseMenu.IsPaused = true;
            Time.timeScale = 0f;
        }

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
        /*
        if (col.gameObject.tag.Equals("Spy-Enemy") || col.gameObject.tag.Equals("Tri-Enemy"))
        {
            pause = true;
        }
        */
        if (col.gameObject.tag.Equals("Enemy"))
        {
            health = health - 100; //player loses 100 health
            GetComponent<SpriteRenderer>().color = Color.red; //flash red on damage
            StartCoroutine(invin()); //invincible for short period after hit
        }

        if (health == 0)  //if die
        {
            instObject = (GameObject)Instantiate(hit, transform.position, transform.rotation); //create explosion temp object
            Destroy(instObject, 1f); //destroy temp explosion object
                                     //this.transform.position = spawn.transform.position; //respawn
                                     //gameObject.SetActive(false);
                                     //Time.timeScale = 0f;  
            this.transform.position = spawn.transform.position;

            //StartCoroutine(wait());       
            //pause = true;
        }

        IEnumerator invin()
        {
            Physics2D.IgnoreLayerCollision(9, 10, true); //ignore collision with enemies
            yield return new WaitForSeconds(2f); // wait time
            GetComponent<SpriteRenderer>().color = Color.white;
            Physics2D.IgnoreLayerCollision(9, 10, false);
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2);

    }

}
