//Paul Santora

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenu;
    public GameObject deadMenu;
    public GameObject winMenu;

    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;

    private void Start()
    {
        pauseMenu.SetActive(false);
        deadMenu.SetActive(false);
        winMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {


        // If the player Presses 'P' the game pauses
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!IsPaused)
            {
                Pause();
            }
        }



        // While the game is paused
        if (IsPaused)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!keyDown)
                {
                    if (index < maxIndex)
                    {
                        index++;
                    }
                    else
                    {
                        index = 0;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!keyDown)
                {
                    if (index > 0)
                    {
                        index--;
                    }
                    else
                    {
                        index = maxIndex;
                    }
                }
            }
            // When player activates button
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (pauseMenu.activeSelf == true)
                {
                    if (index == 0)
                    {
                        Resume();
                    }
                    else if (index == 1)
                    {
                        QuitGame();
                    }
                }
                if (deadMenu.activeSelf == true)
                {
                    if (index == 0)
                    {
                        Time.timeScale = 1f;
                        IsPaused = false;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    }
                    else if (index == 1)
                    {
                        QuitGame();
                    }
                }
                if (winMenu.activeSelf == true)
                {
                    if (index == 0)
                    {
                        //Next Level
                        Time.timeScale = 1f;
                        IsPaused = false;

                        if ((SceneManager.GetActiveScene().buildIndex) == 5)
                            SceneManager.LoadScene(1);
                        else
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                    }
                    else if (index == 1)
                    {
                        Debug.Log("this right here");
                        //go to main menu
                        QuitGame();
                    }
                }
            }
        }

    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;

    }

    public void QuitGame()
    {
        IsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
