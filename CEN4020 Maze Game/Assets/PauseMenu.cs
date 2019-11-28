//Paul Santora

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject deadMenu;
    public GameObject winMenu;
    public GameObject background;

    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex;

    private void Start()
    {
        pauseMenu.SetActive(false);
        background.SetActive(false);
        deadMenu.SetActive(false);
        background.SetActive(false);
        winMenu.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (IsPaused)
            Debug.Log("is paused");
        else
            Debug.Log("is not paused");

        if (pauseMenu.activeSelf == true)
            Debug.Log("Active4");
        else
            Debug.Log("no longer active but whyyyy");

        // If the player Presses 'P' the game pauses
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!IsPaused)
            {
                Debug.Log("is not paused");
                Pause();

                if (pauseMenu.activeSelf == true)
                    Debug.Log("Active2");

            }
            else
            {
                Debug.Log("is paused");
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
                        Debug.Log("GETTING SET TO FALSE HERE");
                        optionsMenu.SetActive(true);
                        pauseMenu.SetActive(false);
                        maxIndex = 3;
                        index = 0;
                    }
                    else if (index == 2)
                    {
                        QuitGame();
                    }
                }
                if (optionsMenu.activeSelf == true)
                {
                    if (index == 0)
                    {
                        
                    }
                    else if (index == 1)
                    {
                        
                    }
                    else if (index == 2)
                    {
                        
                    }
                    else if (index == 3)
                    {
                        optionsMenu.SetActive(false);
                        pauseMenu.SetActive(true);
                        maxIndex = 2;
                        index = 1;
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
                    else if (index == 2)
                    {
                        Debug.Log("QUIT");
                        Application.Quit();
                    }
                }
                if (winMenu.activeSelf == true)
                {
                    if (index == 0)
                    {
                        //Next Level
                        //SceneManager.LoadScene();
                    }
                    else if (index == 1)
                    {
                        //go to main menu
                        QuitGame();
                    }
                    else if (index == 1)
                    {
                        Debug.Log("QUIT");
                        Application.Quit();
                    }
                }
            }
        }


        if (pauseMenu.activeSelf == true)
            Debug.Log("Active3");
    }

    public void Resume()
    {
        Debug.Log("GETTING SET TO FALSE HERE");

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;

        if (pauseMenu.activeSelf == true)
            Debug.Log("ACTIVE HERE");

    }

    public void QuitGame()
    {
        Debug.Log("GETTING SET TO FALSE HERE");

        IsPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
