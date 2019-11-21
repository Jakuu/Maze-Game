using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jason Hamilton
public class ItemObjective : IObjective
{
    private bool _status = false;
    private string _requirements;

    public ItemObjective(string itemName)
    {
        _requirements = itemName;
    }

    public void Complete()
    {
        _status = true;
    }

    public bool isComplete()
    {
        return _status;
    }

    public string getRequirements()
    {
        return _requirements;
    }
}
