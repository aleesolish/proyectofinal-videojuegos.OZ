using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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

    public Text countText;
    private int count;
    public Text winText;




    public Transform muzzle;

    public GameObject bullet;





    private void Start()
    {
        anim = GetComponent<Animator>();
        winText.text = "";
        count = 0;
        SetCounter();

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
  

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.tag == "pickup") {
            Destroy(other.gameObject);
            count = count + 1;
            SetCounter();
        }

	}

    void SetCounter(){
        countText.text = "Gemas:" + count.ToString() + "/10";
        if (count >= 10 ){
            winText.text = "Obtuviste todas las gemas!";
        }
        

    }
}