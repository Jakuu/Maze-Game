// Abbey Centers
// https://www.youtube.com/watch?v=CNNeD9oT4DY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class is responsible for displaying a victory message to the user
// if the maze exit is found and the "item retrieval" objective
// is accomplished successfully

public class TriggerEvent : MonoBehaviour
{
    // winning text to display
    public GameObject winningText;

    // game over text to display
    public GameObject gameOverText;

    // the key object that has to be collected before exiting the maze in order to win
    public KeyTrigger keyObj;

    // so that door can later be set to a trigger after objective is complete
    private BoxCollider2D _collider = null;

    // hide the winning text from the screen
    private void Start()
    {
        winningText.SetActive(false);
    }

    // this function takes a player object as a parameter
    // the player object must have a 2D collider component
    // this function is triggered when the player parameter comes in contact with the game object
    void OnTriggerEnter2D(Collider2D player)
    {
        // if the player is equal to our Player object
        if (player.gameObject.tag == "Player")
        {
            // if the key has been collected / the objective has been completed
            if (keyObj.isComplete())
            {
                // destroy text that could display game over message
                Destroy(gameOverText);

                // display victory message to the user
                winningText.SetActive(true);
                StartCoroutine("WaitForSec");
            }
        }
    }

    // destroy the current game object and message so that it is removed from the screen
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(winningText);
        Destroy(gameObject);
    }
}