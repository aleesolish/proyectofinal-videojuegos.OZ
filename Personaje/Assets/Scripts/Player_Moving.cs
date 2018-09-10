using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moving : MonoBehaviour
{

    public float topSpeed = 1f;
    bool facingRight = true;

    Animator anim;

    bool grounded = false;

    public Transform groundCheck;

    float groundRadius =0.2f;

    public float jumpForce = 700f;

    public LayerMask whatIsGround;




    public Transform muzzle;

    public GameObject bullet;





    private void Start()
    {
        anim = GetComponent<Animator>();
    }





    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);


        anim.SetBool("Ground", grounded);

        anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);


       
        float move = Input.GetAxis("Horizontal");

        GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));


        if (move  > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
    }

    private void Update()
    {
        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {

            anim.SetBool("Ground", false);

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        if(Input.GetButtonDown("Fire1"))
        {
            GameObject mBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);

            mBullet.transform.parent = GameObject.Find("GameManager").transform;
            mBullet.GetComponent<Renderer>().sortingLayerName = "Player1";

        }


    }
    void Flip(){

        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }
    /*
    private void OnCollisionEnter2D(Collision2D obj)
    {


        if (obj.transform.tag == "rubie")
        {
            Destroy(obj.transform.gameObject);
        }

    }*/

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "pickup") {
            Destroy(other.gameObject);
            Debug.Log("Rubie picked");
        }

	}
}