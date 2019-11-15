using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectiveTracker : MonoBehaviour
{
    private ButtonTrigger quest;
    public GameObject obj;
    Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        quest = obj.GetComponent<ButtonTrigger>();
        txt.text = obj.GetComponent<ButtonTrigger>().getObjective();
        //txt.text = quest.getRequirements();
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
