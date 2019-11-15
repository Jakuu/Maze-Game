using UnityEngine;

//Jason Hamilton

public class ButtonTrigger : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private ItemObjective _objective;
    public Sprite completeSprite;

    void Start()
    {
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();

        _objective = new ItemObjective("Push Button");
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
            _sprite.sprite = completeSprite;
            _objective.Complete();
        }
    }

    public string getObjective()
    {
        return "Push Button";
        //return _objective.getRequirements();
    }
}
