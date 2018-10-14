using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    Animator anim;
    [SerializeField]
    Slider HealthSlider;

   public static float maxHealth = 100;
    public float currentHealth;
    public bool Damage;
    public GameMaster LevelManager;
   

    void Start()
    {

        anim = GetComponent<Animator>();
        HealthSlider.value = maxHealth;
        currentHealth = HealthSlider.value;



        LevelManager = FindObjectOfType<GameMaster>();



    }

    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Spikes")
        {
            HealthSlider.value -= 1.5f;
            currentHealth = HealthSlider.value;
            anim.SetTrigger("Damage"); // Activa el Trigger en el Animator
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; //Resetea la velocidad del personaje para que no avance mientras ataca
        }

        if (col.gameObject.tag == "Engranes")
        {
            HealthSlider.value -= 1.5f;
            currentHealth = HealthSlider.value;
            anim.SetTrigger("Damage"); // Activa el Trigger en el Animator
            GetComponent<Rigidbody2D>().velocity = Vector2.zero; //Resetea la velocidad del personaje para que no avance mientras ataca
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
       
      
         
        }
  


}


