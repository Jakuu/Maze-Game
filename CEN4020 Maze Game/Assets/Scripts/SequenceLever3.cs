using UnityEngine;

//Jason Hamilton

public class SequenceLever3 : MonoBehaviour
{
    private SpriteRenderer _sprite;
    private ItemObjective _objective;
    public GameObject lever_1;
    private SequenceLever2 btrig;
    public Sprite completeSprite;

    void Start()
    {
        _sprite = this.gameObject.GetComponent<SpriteRenderer>();
        btrig = lever_1.GetComponent<SequenceLever2>();
        _objective = new ItemObjective("Activate Blue Lever");
    }

    public bool isComplete()
    {
        return _objective.isComplete();
    }

    // Hide sprite on player contact, update objective status
    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player" && btrig.isComplete())
        {
            _sprite.sprite = completeSprite;
            _objective.Complete();
        }
    }

    public string getObjective()
    {
        //return "Push Button";
        return _objective.getRequirements();
    }
}
