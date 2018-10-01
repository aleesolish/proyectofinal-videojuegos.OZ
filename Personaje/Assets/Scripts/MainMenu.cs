using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject PrincipalUI;

    private bool play = false;
    private bool exit = false;


    private void Start()
    {


    }



    private void Update()
    {


    }




    public void Resume()
    {

    }



    public void PlayStage1()
    {
        SceneManager.LoadScene(1);

    }

    public void Exit()
    {
        Application.Quit();

    }


}

