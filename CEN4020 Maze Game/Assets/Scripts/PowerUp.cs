using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Abbey Centers
// source: https://www.youtube.com/watch?v=CLSiRf_OrBk

public class PowerUp : MonoBehaviour
{
    // amount to add to the player's score
    public float multiplier = 1.4f;

    // tilemap gameobject to apply script to --> PowerUps
    public GameObject tilemapGameObject;

    // reference the Tilemap component of provided gameObject
    Tilemap tilemap;

    void Start()
    {
        // get component only if the tilemapGameObject member has been assigned an actual game object
        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
    }

    // action performed when player collides with one of the 
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

            // use the player's current position to find and hide the power-up tile at that position
            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);

            // apply effect to player
            PlayerStats stats = player.GetComponent<PlayerStats>();
            if (stats.score == 0)
                stats.score = 100;

            stats.score *= multiplier;
        }
    }
}


  
