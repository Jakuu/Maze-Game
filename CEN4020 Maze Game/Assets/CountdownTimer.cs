// Abbey Centers
// https://www.youtube.com/watch?v=o0j7PdU88a4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
    // game over text
    public GameObject gameOverText;
    public GameObject winningText;

    float currentTime;
    float startingTime = 20;

    [SerializeField] Text countdownText;

    private void Start()
    {
        gameOverText.SetActive(false);
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0.00");

        if (currentTime <= 0)
        {
            Destroy(winningText);
            currentTime = 0;
            gameOverText.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameOverText);
        Destroy(gameObject);
    }
}
