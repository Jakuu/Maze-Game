// Abbey Centers
// https://www.youtube.com/watch?v=o0j7PdU88a4

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreCount : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Text scoreText;
    private PlayerStats stats;

    private void Start()
    {
        stats = player.GetComponent<PlayerStats>();
        scoreText.text = stats.score.ToString("0.0");
    }

    private void Update()
    {
        scoreText.text = stats.score.ToString("0.0");
    }
  
}
