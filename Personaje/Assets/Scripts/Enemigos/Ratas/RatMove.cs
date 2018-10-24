using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMove : MonoBehaviour
{
    public float moveSpeed;
    bool moveRight;
    public Transform Weakness;
    public Collision2D[] contacts;
    public bool colliding;
    Animator anim;

    public Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        moveRight = true;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TurnAround"))
        {
            if (moveRight)
            {

                moveRight = false;
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
                Flip();
            }
            else
            {
                moveRight = true;
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
                Flip();
            }
        }

        if(other.gameObject.CompareTag("Player")){
            if (moveRight)
            {

                moveRight = false;
                transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
                Flip();
            }
            else
            {
                moveRight = true;
                transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
                Flip();
            }
        }
    

    }
    void Flip()
    {
        // Diciendole que apuntamos a la direccion opuesta
        moveRight = !moveRight;
        // Obtener LOCALSCALE
        Vector3 theScale = transform.localScale;
        // Voltaer en eje X
        theScale.x *= -1;
        // Aplicar transformacion en LOCAL SCALE
        transform.localScale = theScale;
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            float height = col.contacts[0].point.y - Weakness.position.y;

            if(height > 0){
               
                Crushed();
                col.rigidbody.AddForce(new Vector2(0, 1200));
            }
        }
    }

    public void Crushed(){

        anim.SetBool("Aplastada", true);
        Destroy(this.gameObject, 1.5f);
        gameObject.tag = "Neutralized";
    }



}
/*  if (other.gameObject.CompareTag("Player"))
{
    if (moveRight)
    {
        moveRight = false;
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
    else
    {
        moveRight = true;
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
    }
}
}

private void OnCollisionEnter2D(Collision2D collision)
{
if (moveRight)
{
    moveRight = false;
    this.transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
}
else
{
    moveRight = true;
    this.transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
}
}*/

