using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetQuests : MonoBehaviour
{
    private List<ButtonTrigger> objList;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        //var quest = obj.GetComponent<ButtonTrigger>();
        objList = new List<ButtonTrigger>();
        objList.Add(obj.GetComponent<ButtonTrigger>());
    }

    public bool isComplete()
    {
        foreach(ButtonTrigger quest in objList)
        {
            if (!quest.isComplete())
                return false;
        }
        return true;
    }
}
