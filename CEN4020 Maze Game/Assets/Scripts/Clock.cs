using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Abbey Centers
// source: https://www.youtube.com/watch?v=CLSiRf_OrBk

public class Clock : MonoBehaviour
{
    // timer text to update
    public CountdownTimer timer;

    // action performed when player collides with one of the clocks
    void OnTriggerEnter2D(Collider2D player)
    {
            // apply effect to timer
            timer.AddTime(5.0f); 

            // destroy clock object
            Destroy(gameObject);
    }
}



