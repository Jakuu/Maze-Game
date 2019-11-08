using UnityEngine;

//Jason Hamilton

public class KeyTrigger : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private ItemObjective _objective;

    void Start()
    {
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();
        _objective = new ItemObjective("key");
    }

    public bool isComplete()
    {
        return _objective.isComplete();
    }

    // Hide sprite on player contact, update objective status
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            _sprite.enabled = false;
            _objective.Complete();
        }
    }
}
