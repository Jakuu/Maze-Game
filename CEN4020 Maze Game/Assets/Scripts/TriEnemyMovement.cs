//David Song
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriEnemyMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject bullet;

    public Transform Player;
    public int MoveSpeed = 2;
    public float MaxDist = 10; //maxdistance to shoot from
    public float MinDist = 5; //collision minimum distance
    float fireRate;
    float nextShot;
    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        nextShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        transform.LookAt(Player);
        

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
            {

            }

        }
        
        
    }

    void Shoot()
    {
        if (Time.deltaTime > nextShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        
            nextShot = Time.deltaTime + fireRate;
        }
    }
}
