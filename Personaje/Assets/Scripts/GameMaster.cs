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
    public Vector3 respawnPoint;
    public static float maxHealth = 100;
    public float currentHealth;

    private void Start()
    {
        HealthPlayer = FindObjectOfType<PlayerHealth>();
        //PointText.text = "Gemas:";
        respawnPoint = transform.position;

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            respawnPoint = GetComponent<Collider2D>().transform.position;
        }
        if (other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
        }
        HealthPlayer.gameObject.SetActive(true);
    }

    public void Respawn()
    {
        HealthPlayer.gameObject.SetActive(false);
        respawnPoint = GetComponent<Collider2D>().transform.position;

    }

    void Update(int Puntos)
    {
        PointText.text = "Gems:" +Puntos;
    }
}


