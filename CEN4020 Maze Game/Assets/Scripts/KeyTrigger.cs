using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Jason Hamilton and Abbey Centers


public class KeyTrigger : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private ItemObjective _objective;
    private Animator _animator = null;
    public GameObject chestOpened;

    public GameObject tilemapGameObject;
    Tilemap tilemap;

    void Start()
    {
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();
        _objective = new ItemObjective("key");
        _animator = GetComponent<Animator>();
        chestOpened.SetActive(false);

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
            _animator.Play("Chest Animation");
            _sprite.enabled = false;
            chestOpened.SetActive(true);

            // set null
            tilemap.ClearAllTiles();
        }
    }
}
