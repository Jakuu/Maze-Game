using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //public GameObject pickupEffect;
    public float multiplier = 1.4f;

    void OnTriggerEnter2D(Collider2D player)
    { 
        if (player.gameObject.tag == "Player")
        {
            Pickup(player);
        }
    }


    void Pickup(Collider2D player)
    {
        // spawn effect
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        // apply effect to player
        PlayerStats stats = player.GetComponent<PlayerStats>();        
        stats.score *= multiplier;

        // remove power up object
        Destroy(gameObject);


    
    }


}


  
