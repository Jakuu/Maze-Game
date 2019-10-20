// Abbey Centers
// https://www.youtube.com/watch?v=CNNeD9oT4DY

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEvent : MonoBehaviour
{
    public GameObject winningText;
    public GameObject gameOverText;

    private void Start()
    {
        winningText.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            // destroy text saying game over
            Destroy(gameOverText);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            winningText.SetActive(true);
            StartCoroutine("WaitForSec");
      
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(winningText);
        Destroy(gameObject);
    }
}
