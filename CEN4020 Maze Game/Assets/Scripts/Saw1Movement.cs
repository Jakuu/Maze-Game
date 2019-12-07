
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw1Movement : MonoBehaviour
{

    public GameObject Player;
    public int temphealth;


    public float moveSpeed = 5f;
    public Rigidbody2D enemyRB;
    public int UnitstoMove = 5;
    public float speed = 250;
    Vector3 movement = new Vector3(0,0,0);

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(1, Mathf.Sin(Time.time) * 3, 0);
        

        //transform.position = new Vector3(1, -2 + Mathf.PingPong(Time.time, 4), 0); //Up and down movement at stable rate
        //transform.Position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(Time.realtimeSinceStartup) * UnitstoMove)); //move from pos1 to pos2 at speed
        //transform.Translate(movement + Vector3.up * Time.time * 5); //Single direction movement
        //enemyRB.transform.position =  movement + Vector3.up * Mathf.Sin(Time.realtimeSinceStartup) * UnitstoMove; //Movement up and down

      

    }


}
