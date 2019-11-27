// Abbey Centers
// https://www.youtube.com/watch?v=o0j7PdU88a4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCount : MonoBehaviour
{
    // reference to player object
    public GameObject player;

    // used to edit the value of displayed score
    [SerializeField] Text scoreText;

    // used to get reference to the player's PlayerStats component 
    private PlayerStats stats;

    private void Start()
    {
        // get reference to player's PlayerStats component
        stats = player.GetComponent<PlayerStats>();

        // set initial score text
        scoreText.text = stats.score.ToString("00000");
    }

    private void Update()
    {
        // score text remains at 0.0 until a power up is collected
        // this value is modifed in the PowerUp script
        scoreText.text = stats.score.ToString("00000");
    }
  
}
