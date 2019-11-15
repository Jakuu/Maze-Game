//Paul Santora

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public int index;
    [SerializeField] bool keyDown;
    [SerializeField] int maxIndex1; //Title Screen Max Index
    [SerializeField] int maxIndex2; //Level Select Max Index
    [SerializeField] int maxIndex3; //Options Menu Max Index
    [SerializeField] GameObject gameObject1; //TitleScreen
    [SerializeField] GameObject gameObject2; //LevelSelect
    [SerializeField] GameObject gameObject3; //OptionsMenu

    // Update is called once per frame
    void Update()
    {
        //While on Title Screen
        if (gameObject1.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!keyDown)
                {
                    if (index < maxIndex1)
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
                if (index > 0)
                {
                    index--;
                }
                else
                {
                    index = maxIndex1;
                }
            }
        }
        //While on Level Select
        if (gameObject2.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!keyDown)
                {
                    if (index < maxIndex2)
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
                if (index > 0)
                {
                    index--;
                }
                else
                {
                    index = maxIndex2;
                }
            }
        }
        //While on Options Menu
        if (gameObject3.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (!keyDown)
                {
                    if (index < maxIndex3)
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
                if (index > 0)
                {
                    index--;
                }
                else
                {
                    index = maxIndex3;
                }
            }
        }
    }
}
