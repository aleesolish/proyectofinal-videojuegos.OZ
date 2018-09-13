﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class Player_Moving : MonoBehaviour
{

    public GameMaster LevelManager;

    // MOVIMIENTO
    public static float topSpeed = 14f; // Maxima velocidad del personaje
    bool facingRight = true; // Indica al Sprita a qué direccón apuntar
    public Animator anim;


    // SALTO
    bool grounded = false;  // Referencia al animator
    public Transform groundCheck;   // transform a los pies del personaje para comprobar si toca el suelo
    float groundRadius = 1f;   // diametro del circulo que detecta el suelo
    public static float jumpForce = 2200f; // Fuerza del salto
    public LayerMask whatIsGround; // Capas que detecta como suelo

    // DOBLE SALTO
    public bool doubleJump = false;// variable del doble salto 



    // DISPARO
    bool isShooting = false;
    public Transform muzzle;
    public GameObject bullet;



    // ATAQUE

    float timeBTattack;
    public float startTimeBTattack;
    public Transform attackPos;
    public float attackRange;

    public LayerMask whatIsEnemies;
    public int damage;

    public Animator camAnim;


   



    private int count;
    public Text PointText;


    private void Start()
    {
        LevelManager = FindObjectOfType<GameMaster>();
        anim = GetComponent<Animator>();

        count = 0;

        SetCounter();

    }



    private void FixedUpdate()
    {

        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {  //Condicion que interrumpe el movimiento si se ataca

            anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);

            // CORRER
            float move = Input.GetAxis("Horizontal"); // obtener la direccion del movimiento
            anim.SetFloat("Speed", Mathf.Abs(move));
            // Le da velocidad al rigidbody en la direccion de move, la velocidad
            GetComponent<Rigidbody2D>().velocity = new Vector2(move * topSpeed, GetComponent<Rigidbody2D>().velocity.y);
            // Condicion para voltear el personaje si se apunta en direccion contraria
            if (move > 0 && !facingRight)
                Flip();
            else if (move < 0 && facingRight)
                Flip();

        }

    }



    private void HandleInput()
    {

    }



    private void Update()

    {
        HandleInput();

        // ATAQUE



        if (timeBTattack <= 0)

        {
            // Entonces se puede atacar
            if (Input.GetKey(KeyCode.Z))
            {
                anim.SetTrigger("Attack"); // Activa el Trigger en el Animator
                camAnim.SetTrigger("Shake");// Animacion Movimiento de camara al golpear

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);


                for (int i = 0; i < enemiesToDamage.Length; i++)
                {

                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero; //Resetea la velocidad
                }

            }


                timeBTattack = startTimeBTattack;
            }
            else
            {
                timeBTattack -= Time.deltaTime;
            }
      


        // Verdadero o falso que el suelo se transformo. toco el grounRadius
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        // Diciendole al animator que tocamos el suelo
        anim.SetBool("Ground", grounded);

        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack")) //Condicion que interrumpe el movimienot si se ataca
        {
            // SALTAR
            if (grounded)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                    doubleJump = true;
                }
            }


            else
            {

                if (doubleJump && Input.GetKeyDown(KeyCode.Space))
                {

                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
                    doubleJump = false;
                }
            }



            // DISPARO

            if (!this.anim.GetCurrentAnimatorStateInfo(0).IsTag("isShooting")) //Condicion que interrumpe el movimienot si se ataca
            {
                if (Input.GetMouseButtonDown(0))

                {
                    anim.SetTrigger("isShooting");
                    GameObject mBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);

                    mBullet.transform.parent = GameObject.Find("GameManager").transform;
                    mBullet.GetComponent<Renderer>().sortingLayerName = "Player1";


                }

            }
            else
            {
                isShooting = false;
            }
        }




    }
    // VOLTEAR AL PERSONAJE
    void Flip()
    {
        // Diciendole que apuntamos a la direccion opuesta
        facingRight = !facingRight;
        // Obtener LOCALSCALE
        Vector3 theScale = transform.localScale;
        // Voltaer en eje X
        theScale.x *= -1;
        // Aplicar transformacion en LOCAL SCALE
        transform.localScale = theScale;
    }


    // Enemigo se vuelve rojo cuando lo golpeas
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            Destroy(other.gameObject);
            count = count+1;

            SetCounter();
        }

    }
    void SetCounter()
    {
        PointText.text = "Ruby: " +  count.ToString();


    }
}