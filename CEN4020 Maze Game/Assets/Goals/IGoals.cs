using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Goals
{

    public interface IGoals : MonoBehaviour
    {
        bool IsComplete();
        void Complete();
        void Display();
    }
}
