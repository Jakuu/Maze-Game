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

    public GameObject player;
    public GameObject highScoreTable;

    // high score UI
    [SerializeField] GameObject HighScoreUI;

    // winning text to display
    [SerializeField] GameObject winMenu;

    // game over text to display
    [SerializeField] GameObject deadMenu;

    // set active/unactive
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject canvasPause;

    // the key object that has to be collected before exiting the maze in order to win
    //public KeyTrigger keyObj;

    // hide the winning text from the screen
    private void Start()
    {
        winMenu.SetActive(false);
        HighScoreUI.SetActive(false);
        deadMenu.SetActive(false);
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
            //if (keyObj.isComplete())
            //{
                // destroy text that could display game over message
                // display victory message to the user




            // get player score
            PlayerStats stats = player.GetComponent<PlayerStats>();

            // get leaderboard table
            HighscoreTable leaderboard = highScoreTable.GetComponent<HighscoreTable>();

            // add user to leaderboard ONLY IF THEY ARE IN TOP 10
            leaderboard.AddHighscoreEntry(stats.score, "Abbey");
            leaderboard.Awake();

            // get min and max of leaderboard

            // check if score is in top ten

            // if yes, ask for user input

            // create canvas similar to highscore table

            // set it to active

            // on key enter pressed, get input and add to highscore entry







            winMenu.SetActive(true);
            HighScoreUI.SetActive(true);
            pauseMenu.SetActive(false);
            canvasPause.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.IsPaused = true;


            //}
        }
    }
}