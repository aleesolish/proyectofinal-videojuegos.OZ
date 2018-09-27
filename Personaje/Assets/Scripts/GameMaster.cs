using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class GameMaster : MonoBehaviour
{
    Animator anim;
    public Player_Moving gamePlayer;
    public PlayerHealth HealthPlayer;
    public float resDelay;
    public Text PointText;
   
    public static float maxHealth = 100;
    public float currentHealth;

    private void Start()
    {
        HealthPlayer = FindObjectOfType<PlayerHealth>();
        //PointText.text = "Gemas:";


    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            //anim.SetBool("IsDead", true);

            {
                //respawnPoint = GetComponent<Collider2D>().transform.position;
            }

        }
    }

}