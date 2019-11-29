// Abbey Centers
// https://www.youtube.com/watch?v=CNNeD9oT4DY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this class is responsible for displaying a victory message to the user
// if the maze exit is found and the "item retrieval" objective
// is accomplished successfully

public class TriggerEvent : MonoBehaviour
{

    public GameObject player;
    public GameObject highScoreTable;
    public GameObject errMsg;
    public GameObject background;
    public string tableName;

    // get name from user
    [SerializeField] Text leaderboardName;

    // high score UI
    [SerializeField] GameObject HighScoreUI;

    // leaderboard name UI
    [SerializeField] GameObject GetLeaderboardNameUI;

    // winning text to display
    [SerializeField] GameObject winMenu;

    // game over text to display
    [SerializeField] GameObject deadMenu;

    // set active/unactive
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject canvasPause;

    HighscoreTable leaderboard;


    // the key object that has to be collected before exiting the maze in order to win
    //public KeyTrigger keyObj;

    // hide the winning text from the screen
    private void Start()
    {
        GetLeaderboardNameUI.SetActive(false);
        HighScoreUI.SetActive(false);
        leaderboard = highScoreTable.GetComponent<HighscoreTable>();
        errMsg.SetActive(false);
        background.SetActive(false);

    }

    // this function takes a player object as a parameter
    // the player object must have a 2D collider component
    // this function is triggered when the player parameter comes in contact with the game object
    void OnTriggerEnter2D(Collider2D player)
    {

        // if the player is equal to our Player object
        if (player.gameObject.tag == "Player")
        {
            int min = 0;


            // if the key has been collected / the objective has been completed
            //if (keyObj.isComplete())
            //{
                // destroy text that could display game over message
                // display victory message to the user

            // get player score
            PlayerStats stats = player.GetComponent<PlayerStats>();

            // get leaderboard table
            //HighscoreTable leaderboard = highScoreTable.GetComponent<HighscoreTable>();

            // get min of top ten leaderboard scores
            string jsonString = PlayerPrefs.GetString(tableName);
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);


            // Sort entry list by Score
            if (highscores != null)
            {
                SortList(highscores);

                // get min of top ten scores
                if (highscores.highscoreEntryList.Count == 10)
                {
                    Debug.Log("equal to 10");
                    min = highscores.highscoreEntryList[9].score;
                }
                else
                {
                    int tmp = highscores.highscoreEntryList.Count - 1;
                    min = highscores.highscoreEntryList[tmp].score;                
                }

                Debug.Log("min: " + min);
            }


            Debug.Log("score: " + stats.score + " and min: " + min);
            // if number of entries is >= 10 and new score is greater than min, put in top ten
            if (highscores.highscoreEntryList.Count < 10)
            {
                Debug.Log("thisone 1");
                winMenu.SetActive(false);
                pauseMenu.SetActive(false);
                Time.timeScale = 0f;
                PauseMenu.IsPaused = true;
                HighScoreUI.SetActive(false);

                // get player name for high score table
                StartCoroutine(getName(stats, leaderboard));

            }
            else if (stats.score > min)
            {
                Debug.Log("thisone 1");
                winMenu.SetActive(false);
                pauseMenu.SetActive(false);
                Time.timeScale = 0f;
                PauseMenu.IsPaused = true;
                HighScoreUI.SetActive(false);

                // get player name for high score table
                StartCoroutine(getName(stats, leaderboard));
            }
            else
            {
                Debug.Log("happening");
                HighScoreUI.SetActive(true);
                winMenu.SetActive(true);
                Time.timeScale = 0f;
                PauseMenu.IsPaused = true;

            }

            // don't prompt the user if the number of entries is >= 10 and score is less than min
             

        }
    }

    private void SortList(Highscores highscores)
    {
        if (highscores.highscoreEntryList.Count > 1)
        {
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
                {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                    {
                        // Swap
                        HighscoreEntry tmp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = tmp;
                    }
                }
            }
        }
    }


    private IEnumerator getName(PlayerStats stats, HighscoreTable leaderboard)
    {
        // show enter name prompt
        background.SetActive(true);
        GetLeaderboardNameUI.SetActive(true);

        // wait for player to press space
        yield return waitForKeyPress(KeyCode.Return, stats, leaderboard); // wait for this function to return

        // remove prompt
        GetLeaderboardNameUI.SetActive(false);
        background.SetActive(false);

    }

    private IEnumerator waitForKeyPress(KeyCode key, PlayerStats stats, HighscoreTable leaderboard)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(key))
            {
                if (leaderboardName.text != "")
                    done = true; // breaks the loop

                // add user to leaderboard
                if (done == true)
                {
                    Time.timeScale = 1f;
                    leaderboard.AddHighscoreEntry(stats.score, leaderboardName.text);
                    leaderboardName.text = "";
                    Time.timeScale = 0f;
                    errMsg.SetActive(false);
                    winMenu.SetActive(true);
                    HighScoreUI.SetActive(true);
                    background.SetActive(false);
                 
                 }


            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }





    private IEnumerator errorMessage()
    {
        // set error message active
        errMsg.SetActive(true);

        yield return new WaitForSeconds(1.0f);

    }


    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * Represents a single High score entry
     * */
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}