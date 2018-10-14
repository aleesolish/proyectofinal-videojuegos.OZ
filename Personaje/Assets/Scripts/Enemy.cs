using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {



    public int Health;
    public float speed;
    public GameObject BloodEffect;
  

    private Animator anim;

	void Start () {
        //anim.GetComponent<Animator>();

    }

    private void Update()
    {
        if (Health <= 0){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    public void TakeDamage (int damage){
        Instantiate (BloodEffect, transform.position, Quaternion.identity);
        Health -= damage;
        Debug.Log("damage TAKEN !");

	}
}
