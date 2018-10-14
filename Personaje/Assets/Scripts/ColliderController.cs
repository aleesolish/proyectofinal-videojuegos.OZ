using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour {

    public CapsuleCollider2D standing;
    public CapsuleCollider2D Crouch;

    Player_Moving Player1;

	// Use this for initialization
	void Start () {
        Player1 = GetComponent<Player_Moving>();
        standing.enabled = true;
        Crouch.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Player1.grounded == false){

            standing.enabled = true;
            Crouch.enabled = false;

        }
        else {
            if(Player1.crouching  == true){

                standing.enabled =  false;
                Crouch.enabled = true;
            }

            else {
                standing.enabled = true;
                Crouch.enabled = false;

            }
        }

	}
}
