using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MultiObjectives : MonoBehaviour, IObjCollection
{
    private List<ButtonTrigger> objList;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    // Start is called before the first frame update
    void Start()
    {
        //var quest = obj.GetComponent<ButtonTrigger>();
        objList = new List<ButtonTrigger>();
        objList.Add(obj1.GetComponent<ButtonTrigger>());
        objList.Add(obj2.GetComponent<ButtonTrigger>());
        objList.Add(obj3.GetComponent<ButtonTrigger>());
    }

    public bool isComplete()
    {
        foreach (ButtonTrigger quest in objList)
        {
            if (!quest.isComplete())
                return false;
        }
        return true;
    }
}
