﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objectives
{
    public class ObjectiveCollection : MonoBehaviour
    {
        // For later implementation of objective list, for now will only have one objective
        //public List<IObjective> objectives = new List<IObjective>();
    }

    public interface IObjective
    {
        bool isComplete();
        void Complete();
        string getRequirements();
    }

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
            return ($"Obtain: {_requirements}");
        }
    }
}