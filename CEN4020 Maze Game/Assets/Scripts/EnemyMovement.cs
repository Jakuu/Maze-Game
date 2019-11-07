using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D enemyrb;
    public int UnitstoMove = 5;
    public float speed = 250;
    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        // movement
        transform.position = movement + Vector2.up * Mathf.Sin(Time.realtimeSinceStartup) * UnitstoMove;


    }

}
