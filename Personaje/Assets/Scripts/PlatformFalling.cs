using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFalling : MonoBehaviour {

    Rigidbody2D Platform; 
    public float fallDelay;


    private void Start()
    {
        Platform = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        GetComponent<Collider2D>().isTrigger = true; 
        Platform.isKinematic = false;
        yield return 0;

    }
}
