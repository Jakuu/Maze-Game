//Paul Santora

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] MenuController menuController;
    [SerializeField] GameObject gameObject1; //TitleScreen
    [SerializeField] GameObject gameObject2; //LevelSelect
    [SerializeField] GameObject gameObject3; //OptionsMenu


    // Loads first level of game
    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //While on TitleScreen
            if (gameObject1.activeSelf == true)
            {
                if (menuController.index == 0)
                {
                    LoadGame();
                }
                else if (menuController.index == 1)
                {
                    menuController.index = 0;
                    gameObject1.SetActive(false);
                    gameObject2.SetActive(true);
                }
                else if (menuController.index == 2)
                {
                    menuController.index = 0;
                    gameObject1.SetActive(false);
                    gameObject3.SetActive(true);
                }
                else if (menuController.index == 3)
                {
                    QuitGame();
                }

            }
            //While on ControlsMenu
            else if (gameObject3.activeSelf == true)
            {
                if (menuController.index == 0)
                {
                    menuController.index = 0;
                    gameObject1.SetActive(true);
                    gameObject3.SetActive(false);
                }
            }
            //While on LevelSelect
            else if (gameObject2.activeSelf == true)
            {
                if (menuController.index == 0)
                {
                    SceneManager.LoadScene(1);
                }
                else if (menuController.index == 1)
                {
                    SceneManager.LoadScene(2);
                }
                else if (menuController.index == 2)
                {
                    SceneManager.LoadScene(3);
                }
                else if (menuController.index == 5)
                {
                    menuController.index = 0;
                    gameObject1.SetActive(true);
                    gameObject2.SetActive(false);
                }
                else if (menuController.index == 3)
                {
                    SceneManager.LoadScene(4);
                }
                else if (menuController.index == 4)
                {
                    SceneManager.LoadScene(5);
                }
            }
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
