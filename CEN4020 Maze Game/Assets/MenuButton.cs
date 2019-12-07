//Paul Santora

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuController menuController;
    [SerializeField] Animator animator;
    [SerializeField] int thisIndex;

    // Update is called once per frame
    void Update()
    {
        if(menuController.index == thisIndex)
        {
            animator.SetBool("select", true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetBool("press", true);
            }
            else if(animator.GetBool("press"))
            {
                animator.SetBool("press", false);
            }
        }
        else
        {
            animator.SetBool("select", false);
        }
    }
}
