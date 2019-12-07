using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTarget : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed = 2;
    public float shootDist = 10; //maxdistance to shoot from
    public float MinDist = 10; //collision minimum distance
    public float Zero = 0;


    // Update is called once per frame
    void Update()
    {

        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= 0 && (Vector3.Distance(transform.position, Player.position) <= MinDist))
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            /*
            if (Vector3.Distance(transform.position, Player.position) <= shootDist)
            {

            }
            */
    }
}
}
