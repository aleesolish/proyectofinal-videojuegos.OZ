using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Rat;
    public int time = 2;
    public int startTime = 0;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnRat", startTime, time); //calls ChangePosition() every 2 secs

    }

    void SpawnRat()
    {
        Instantiate(Rat, transform.position, Quaternion.identity);
    }
}


