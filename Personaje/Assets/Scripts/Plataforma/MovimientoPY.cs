using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPY : MonoBehaviour
{
    
    float dirY, moveSpeed = 8f;
    bool moveUp = true;
    float initialPosition;

    public GameObject tope1;
    public GameObject tope2;


    // Use this for initialization
    void Start()
    {
        initialPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > (tope1.transform.position.y))
        {
            moveUp = false;
        }
        if (transform.position.y < (tope2.transform.position.y))
        {
            moveUp = true;
        }

        if (moveUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
}
