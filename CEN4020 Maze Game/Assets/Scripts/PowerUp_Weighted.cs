using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Weighted : MonoBehaviour
{
    public int add = 25;
    public GameObject player;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            PickUp();
    }

    void PickUp()
    {
        // apply effect to player
        PlayerStats stats = player.GetComponent<PlayerStats>();
        if (stats.score == 0)
            stats.score = 25;

        stats.score += add;
        Destroy(gameObject);
    }
}
