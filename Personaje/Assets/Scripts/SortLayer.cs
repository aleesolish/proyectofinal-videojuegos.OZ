using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortLayer : MonoBehaviour
{

    public string sortLayerName;      //Nombre del SortingLayer



    // Use this for initialization
    void Start()
    {
        // Toma todos los sprites que son hijos del Gameobject del script al que esta ligado

        foreach (SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()){


            sr.GetComponent<Renderer>().sortingLayerName = sortLayerName;
        }

    }

}