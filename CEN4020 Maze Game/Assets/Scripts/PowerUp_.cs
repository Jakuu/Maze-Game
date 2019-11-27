using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_ : MonoBehaviour
{
    public float multiplier = 1.4f;

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
            stats.score = 100;

        stats.score *= multiplier;
        Destroy(gameObject);
    }
}
