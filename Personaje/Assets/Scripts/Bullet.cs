using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public float bulletSpeed;
    public float HitRange;
    public Player_Moving player1;
    public Transform BulletHit;
    public LayerMask whatIsEnemies;


    private void Start()
    {
        player1 = FindObjectOfType<Player_Moving>();

        if (player1.transform.localScale.x < 0)
        {
            bulletSpeed = -bulletSpeed;

            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }



    void OnTriggerEnter2D(Collider2D other)
    {
       
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, GetComponent<Rigidbody2D>().velocity.y);
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(BulletHit.position, HitRange, whatIsEnemies);
            DestroyObject(gameObject, 3f);


    }
}


