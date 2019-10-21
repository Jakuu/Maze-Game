// Abbey Centers
// https://www.youtube.com/watch?v=o0j7PdU88a4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this class is responsible for decrementing the countdown timer until it reaches 0 seconds

public class CountdownTimer : MonoBehaviour
{
    // game over text
    public GameObject gameOverText;

    // winning text
    public GameObject winningText;

    // time to display on the CountdownText object
    float currentTime;

    // amount of time the player has to complete the level
    float startingTime = 20;

    // private member data
    [SerializeField] Text countdownText;

    // hide the game over text from the screen and
    // set the initial start time of the timer
    private void Start()
    {
        gameOverText.SetActive(false);
        currentTime = startingTime;
    }

    // update the countdownText once per frame
    private void Update()
    {
        // decrease current time by 1 each second
        currentTime -= 1 * Time.deltaTime;

        // convert to string without displaying decimal values
        countdownText.text = currentTime.ToString("0");

        // do not display time less than 0 seconds
        if (currentTime <= 0)
        {
            Destroy(winningText);
            currentTime = 0;

            // display to the user that the game is over
            gameOverText.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    // destroy game over text and winning text so that neither can be 
    // displayed again for this level
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameOverText);
        Destroy(gameObject);
    }
}
