using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Jason Hamilton
// Abbey Centers: added chest animation on player collision
//  if we want multiple exists with mutliple barriers, the Barriers
//  tilemap can be used. Once the objective is complete, all barriers
//  will disappear due to the ClearAllTiles method


public class KeyTrigger : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private ItemObjective _objective;
    private Animator _animator = null;
    public GameObject chestOpened;

    // reference to Barriers tilemap
    public GameObject tilemapGameObject;
    Tilemap tilemap;

    void Start()
    {
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();
        _objective = new ItemObjective("key");
        _animator = GetComponent<Animator>();   // used to animate the treasure chest to open on player collision
        chestOpened.SetActive(false);           // hide background sprite of open treasure chest

        // get tilemap component if game object assigned
        if (tilemapGameObject != null)
        {
            tilemap = tilemapGameObject.GetComponent<Tilemap>();
        }
    }

    public bool isComplete()
    {
        return _objective.isComplete();
    }

    // Hide sprite on player contact, update objective status
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            _objective.Complete();

            // aniamte chest opening on player collision
            _animator.Play("Chest Animation");

            // hide closed chest sprite
            _sprite.enabled = false;

            // set open chest sprite to visible
            chestOpened.SetActive(true);

            // hide barrier tiles
            tilemap.ClearAllTiles();
        }
    }
}
