// Abbey Centers
// https://www.youtube.com/watch?v=o0j7PdU88a4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
    // game over text

    float currentTime;
    [SerializeField] float startingTime;

    [SerializeField] Text countdownText;

    [SerializeField] GameObject deadMenu;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject canvasPause;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("00.00");

        if (currentTime <= 0)
        {
            currentTime = 0;
            //pause game and display dead menu
            //to be added later



            deadMenu.SetActive(true);
            pauseMenu.SetActive(false);
            canvasPause.SetActive(true);
            Time.timeScale = 0f;
            PauseMenu.IsPaused = true;
        }
    }

    public void AddTime(float x)
    {
        currentTime += x;
    }
}
