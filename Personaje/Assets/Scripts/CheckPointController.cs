using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour {


    public Sprite Flag;
    private SpriteRenderer checkpointSpriteRndr;

    public bool checkpointReached;


	// Use this for initialization
	void Start () {


        checkpointSpriteRndr = GetComponent<SpriteRenderer>();



    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag =="Player")
        {
            checkpointReached = true;
        }

    }

}
