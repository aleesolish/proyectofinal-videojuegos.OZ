using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoP : MonoBehaviour
{
    float dirX, moveSpeed = 8f;
    bool moveRight = true;
    float initialPosition;

    public GameObject tope1;
    public GameObject tope2;


    // Use this for initialization
    void Start()
    {


        initialPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > (tope1.transform.position.x))
        {
            moveRight = false;
        }
        if (transform.position.x < (tope2.transform.position.x))
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
