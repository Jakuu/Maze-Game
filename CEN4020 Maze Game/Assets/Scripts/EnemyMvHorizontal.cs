using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMvHorizontal : MonoBehaviour
{

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 2f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;

    private int left = 0;
    private int right = 1;

    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy


        //move enemy: 
        if (left == 1)
        {
            left = 0; right = 1;
            movementDirection = new Vector2(-1.0f, 0.0f).normalized;
            movementPerSecond = movementDirection * characterVelocity;
        }
        else
        {
            left = 1; right = 0;
            movementDirection = new Vector2(1.0f, 0.0f).normalized;
            movementPerSecond = movementDirection * characterVelocity;
        }
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        
        /* if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }*/
        

        //calcuateNewMovementVector();

        // move enemy
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));
        
    

    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
           // latestDirectionChangeTime = 0f;
            calcuateNewMovementVector();



        }
    }

}
