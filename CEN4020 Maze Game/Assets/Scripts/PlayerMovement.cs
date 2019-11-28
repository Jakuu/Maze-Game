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


    private GameObject instObject;
    public float moveSpeed = 5f;
    public int health = 3;
    public Rigidbody2D rb;

    Vector2 movement;

    bool pause = false;


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
        if (col.gameObject.tag.Equals("Spy-Enemy") || col.gameObject.tag.Equals("Tri-Enemy"))
        {
            pause = true;
        }
    }


}
