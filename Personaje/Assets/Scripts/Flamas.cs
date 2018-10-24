using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamas : MonoBehaviour
{

    public CapsuleCollider2D FlamaAlta;
    public CapsuleCollider2D FlamaBaja;
    public Animator anim;
    public bool Llama;
    public bool cool;

    // Use this for initialization
    void Start()
    {

        FlamaAlta.enabled = false;
        FlamaBaja.enabled = true;
        StartCoroutine(Sube());
    }

    // Update is called once per frame
    void Update()
    {

          
        }



    IEnumerator Sube()
    {
       
        float active = 3;


        FlamaAlta.enabled = true;
        FlamaBaja.enabled = false;
        anim.SetBool("FuegoSube", Llama);
        yield return new WaitForSeconds(active);  // Tiempo en que no puede ser dañado de nuevo


        StartCoroutine(Baja());
    }



    IEnumerator Baja()
    {


        float CountDown = 2;


        FlamaAlta.enabled = false;
        FlamaBaja.enabled = true;
        anim.SetBool("FuegoBaja", cool);
        yield return new WaitForSeconds(CountDown);  // Tiempo en que no puede ser dañado de nuevo

        StartCoroutine(Sube());

    }
}
