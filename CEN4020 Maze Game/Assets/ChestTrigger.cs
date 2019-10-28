using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private ItemObjective _objective;

    private Animator _animator = null;

    public GameObject chestOpened;

    void Start()
    {
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();
        _objective = new ItemObjective("key");

        _animator = GetComponent<Animator>();
        chestOpened.SetActive(false);
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
            //StartCoroutine("WaitForSec");
        }
    }

    // destroy the current game object and message so that it is removed from the screen
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);
       
    }

}
