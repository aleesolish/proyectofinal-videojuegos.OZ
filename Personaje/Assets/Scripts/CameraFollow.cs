using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //El target al que sigue
    public Transform target;

    //inicia en cero la velocidad
    Vector3 velocity = Vector3.zero;

    //que siga al target
    public float smoothTime = .15f;

    //habilita limite velocidad max en y
    public bool YMaxEnabled = false;
    public float YMaxValue = 0;

    //habilita limite velocidad min en y
    public bool YMinEnabled = false;
    public float YMinValue = 0;

    //habilita limite velocidad max en x
    public bool XMaxEnabled = false;
    public float XMaxValue = 0;

    //habilita limite velocidad min en x
    public bool XMinEnabled = false;
    public float XMinValue = 0;


    private void FixedUpdate()
    {
        //Posicion del TARGET

        Vector3 targetPos = target.position;
       



        //VERTICAL

        if (YMinEnabled && YMaxEnabled) 
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue,YMaxValue);

        else if(YMinEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);

        else if (YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);



        //HORIZONTAL

        if (XMinEnabled && XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);

        else if (XMinEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, target.position.x);

        else if (XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);



        //ALINEA LA CAMARA A LOS TARGETS AL EJE Z
        targetPos.z = transform.position.z;
        //usa el smooth gamp para mover la camara radualmente
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);



    }

}

