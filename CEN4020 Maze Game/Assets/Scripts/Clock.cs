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

    // tilemap gameobject to apply script to --> Clocks
    public GameObject tilemapGameObject;

    // references the Tilemap component of provided gameObject
    Tilemap tilemap;

    void Start()
    {
        // get component only if the tilemapGameObject member has been assigned an actual game object
        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
    }

    // action performed when player collides with one of the clocks
    void OnTriggerEnter2D(Collider2D player)
    {
        // to get the position of the player on tile collision
        Vector3 hitPosition = Vector3.zero;

        // if the tilemap member has been assigned and the gameobject tag corresponds to the player
        if (tilemap != null && player.gameObject.tag == "Player")
        {
            // get the x position of the player
            hitPosition.x = player.transform.position.x;

            // get the y position of the player
            hitPosition.y = player.transform.position.y;

            // use the player's current position to find and hide the clock tile at that position
            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);

            // apply effect to timer
            timer.AddTime(5.0f); 
        }
    }
}



