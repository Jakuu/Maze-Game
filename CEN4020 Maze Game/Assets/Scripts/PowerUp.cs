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
            Debug.Log("found");
            // get the x position of the player
            hitPosition.x = player.transform.position.x;

            // get the y position of the player
            hitPosition.y = player.transform.position.y;

           // Destroy(this);

            tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);

            Debug.Log("hit position x: " + hitPosition.x + " and position y: " + hitPosition.y);
            //Grid grid = transform.parent.GetComponent<Grid>();
           // Vector3Int tPos = tilemap.WorldToCell(player.transform.position);

           // Vector3Int tPos = player.transform.position;
           // Debug.Log("name : " + tilemap.GetTile(lPos).name + " & position : " + lPos);


           // tilemap.SetTile(tilemap.WorldToCell(lPos), null);

            // use the player's current position to find and hide the power-up tile at that position
            //tilemap.SetTile(tPos, null);
            

            BoundsInt bounds = tilemap.cellBounds;
            TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

            for (int x = 0; x < bounds.size.x; x++)
            {
                for (int y = 0; y < bounds.size.y; y++)
                {
                    TileBase tile = allTiles[x + y * bounds.size.x];
                    if (tile != null)
                    {
                        Debug.Log("x:" + x + " y:" + y + " tile:" + tile.name);

                    }
                    /*else
                    {
                        Debug.Log("x:" + x + " y:" + y + " tile: (null)");
                    }*/
                }
            }        




            // use the player's current position to find and hide the power-up tile at that position
            //tilemap.SetTile(tilemap.WorldToCell(hitPosition), null);

            // apply effect to player
            PlayerStats stats = player.GetComponent<PlayerStats>();
            if (stats.score == 0)
                stats.score = 100;

            stats.score *= multiplier;
        }
    }

    //--------------------------------------
   /* void OnTriggerEnter2D(Collider2D other)    
    {
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("found");

            List<Vector3> availablePlaces;
            //tileMap = transform.GetComponentInParent<Tilemap>();
            availablePlaces = new List<Vector3>();
 
            for (int n = tileMap.cellBounds.xMin; n < tileMap.cellBounds.xMax; n++)
            {
                for (int p = tileMap.cellBounds.yMin; p < tileMap.cellBounds.yMax; p++)
                {
                    Vector3Int localPlace = (new Vector3Int(n, p, (int)tileMap.transform.position.y));
                    Vector3 place = tileMap.CellToWorld(localPlace);
                    if (tileMap.HasTile(localPlace))
                    {
                        //Tile at "place"
                        availablePlaces.Add(place);

                    }
                    else
                    {
                        //No tile at "place"
                    }
                }
            }
        }
    } 

    */

    // action performed when player collides with one of the 
  /*  void OnTriggerEnter2D(Collider2D player)
    {
        // to get the position of the player on tile collision
        Vector3 hitPosition = Vector3.zero;

        // if the tilemap member has been assigned and the gameobject tag corresponds to the player
        if (tilemap != null && player.gameObject.tag == "Player")
        {
            Debug.Log("found it\n");
            // get the x position of the player
            hitPosition.x = player.transform.position.x;

            Debug.Log("hitosition.x = " + hitPosition.x);

            // get the y position of the player
            hitPosition.y = player.transform.position.y;

            Debug.Log("hitosition.y = " + hitPosition.y);
            

            Grid grid = transform.parent.GetComponent<Grid>();
            Vector3Int tPos = WorldToCell(player.transform.position);

            //Vector3Int tPos = player.transform.position;
            //Debug.Log("name : " + tilemap.GetTile(lPos).name + " & position : " + lPos);

            // use the player's current position to find and hide the power-up tile at that position
            tilemap.SetTile(tPos, null);

            // apply effect to player
            PlayerStats stats = player.GetComponent<PlayerStats>();
            if (stats.score == 0)
                stats.score = 100;

            stats.score *= multiplier;
        }
    }
     */
}


  
