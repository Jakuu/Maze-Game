using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SequenceTracker3 : MonoBehaviour
{
    private SequenceLever3 quest;
    public GameObject obj;
    Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        quest = obj.GetComponent<SequenceLever3>();
        txt.text = obj.GetComponent<SequenceLever3>().getObjective();
        //txt.text = quest.getRequirements();
    }

    public bool isComplete()
    {
        if (quest.isComplete())
            return true;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (quest.isComplete())
            txt.text = $"{quest.getObjective()}: Complete";
        else
            txt.text = $"{quest.getObjective()}: Incomplete";

    }
}
