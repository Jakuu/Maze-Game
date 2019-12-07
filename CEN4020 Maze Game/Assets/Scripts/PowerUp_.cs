using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_ : MonoBehaviour
{
    public int add = 25;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            PickUp(other);
    }

    void PickUp(Collider2D player)
    {
        // apply effect to player
        PlayerStats stats = player.GetComponent<PlayerStats>();
        if (stats.score == 0)
            stats.score = 25;

        stats.score += add;
        Destroy(gameObject);
    }
}
