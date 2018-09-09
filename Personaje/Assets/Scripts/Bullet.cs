using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    public float bulletSpeed;

    public Player_Moving player1;

    private void Start()
    {
        player1 = FindObjectOfType<Player_Moving>();

        if (player1.transform.localScale.x < 0)
        {
            bulletSpeed = -bulletSpeed;

            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
            
    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);
        DestroyObject(gameObject, 3f);
    }
}
