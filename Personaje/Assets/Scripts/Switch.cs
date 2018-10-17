using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {


    [SerializeField]
    GameObject switchOFF;

    [SerializeField]
    GameObject switchON;

    public bool isON = false;



    // Use this for initialization
    void Start () {

        gameObject.GetComponent<SpriteRenderer>().sprite = switchOFF.GetComponent<SpriteRenderer>().sprite;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = switchON.GetComponent<SpriteRenderer>().sprite;

        isON = true;
       
    }

}
