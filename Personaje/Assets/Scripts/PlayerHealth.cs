using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    [SerializeField]
    Slider HealthSlider;

    float maxHealth = 100;
    float currentHealth;


    void Start()
    {
        HealthSlider.value = maxHealth;
        currentHealth = HealthSlider.value;
    }

    private void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.tag == "Spikes")
        {
            HealthSlider.value -= 1.5f;
            currentHealth = HealthSlider.value;
        
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!");
        }
    }
}
