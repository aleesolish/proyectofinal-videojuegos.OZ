using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public BoxCollider2D Close;
    public BoxCollider2D Open;

    Switch SwitchState;

    Animator anim;
    // Use this for initialization
    void Start()
    {
   
        Close.enabled = true;
        Open.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (SwitchState.isON == false)
        {

            Close.enabled = true;
            Open.enabled = false;

        }
        else
        {
            if (SwitchState.isON == true)
            {
                anim.SetTrigger("OpenDoor");
                Close.enabled = false;
                Open.enabled = true;
            }

            else
            {
                Close.enabled = true;
                Open.enabled = false;

            }
        }

    }
}