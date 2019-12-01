using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SequenceObjectives : MonoBehaviour, IObjCollection
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;
    private SequenceLever1 l1;
    private SequenceLever2 l2;
    private SequenceLever3 l3;

    // Start is called before the first frame update
    void Start()
    {
        //var quest = obj.GetComponent<ButtonTrigger>();
        //objList.Add(obj1.GetComponent<SequenceLever1>());
        //objList.Add(obj2.GetComponent<SequenceLever2>());
        //objList.Add(obj3.GetComponent<SequenceLever3>());
        l1 = obj1.GetComponent<SequenceLever1>();
        l2 = obj2.GetComponent<SequenceLever2>();
        l3 = obj3.GetComponent<SequenceLever3>();
    }

    public bool isComplete()
    {
        if (l1.isComplete() && l2.isComplete() && l3.isComplete())
            return true;
        return false;
    }
}
