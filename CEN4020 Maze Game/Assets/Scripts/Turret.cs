using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    public GameObject bullet;

    float fireRate;
    float nextShot;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 1f;
        nextShot = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) <= 10)
        {

            Vector3 difference = target.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            Shoot();
        }
    }

    void Shoot()
    {
        if (Time.time > nextShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextShot = Time.time + fireRate;
        }
    }
}
