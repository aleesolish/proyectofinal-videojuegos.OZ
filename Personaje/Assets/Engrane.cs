using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engrane : MonoBehaviour {


    public float gearSpeed = 300;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(0, 0, gearSpeed*Time.deltaTime);


	}
}
