using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Abbey Centers

public class Clock : MonoBehaviour
{
    //public GameObject pickupEffect;
    public float multiplier = 1.4f;
    public CountdownTimer timer;
    public GameObject tilemapGameObject;
    Tilemap tilemap;

    void Start()
    {
        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        Vector3 hitPosition = Vector3.zero;
        if (tilemap != null && player.gameObject.tag == "Player")
        {
            hitPosition.x = player.transform.position.x;
            hitPosition.y = player.transform.position.y;
            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);

            // apply effect to timer
            timer.AddTime(5.0f);
           
           
        }
    }
}



