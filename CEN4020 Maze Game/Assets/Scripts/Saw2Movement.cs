
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw2Movement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D enemyRB;
    public int UnitstoMove = 5;
    public float speed = 250;
    Vector3 movement;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //enemyRB.velocity = new Vector2(moveSpeed, enemyRB.velocity.y);// movement * Mathf.Sin(Time.realtimeSinceStartup) * UnitstoMove;
        //transform.localScale = new Vector2(up, transform.localScale.y);

        //transform.Translate(movement + Vector3.up * Time.time * 5);
        transform.position = new Vector3(11, Mathf.Sin(Time.time) * 3, 0);
        //enemyRB.transform.position =  movement + Vector3.up * Mathf.Sin(Time.realtimeSinceStartup) * UnitstoMove;
        //transform.localPosition = Vector3.Lerp(pos1, pos2, (Mathf.Sin(Time.realtimeSinceStartup) * UnitstoMove));


    }


}
