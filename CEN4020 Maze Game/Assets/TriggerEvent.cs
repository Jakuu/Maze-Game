// Abbey Centers
// https://www.youtube.com/watch?v=CNNeD9oT4DY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    public GameObject winningText;
    public GameObject gameOverText;
    public KeyTrigger keyObj;

    private void Start()
    {
        winningText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            if(keyObj.isComplete())
            {
                // destroy text saying game over
                Destroy(gameOverText);

                winningText.SetActive(true);
                StartCoroutine("WaitForSec");
            }
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(winningText);
        Destroy(gameObject);
    }
}
