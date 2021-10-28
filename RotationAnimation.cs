using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    bool bewegung;
    float zeitGesamt;
    float winkelGesamt;
    float bewegungZeitStart;
    float zeitAnteilAlt;


    void Start()
    {
        bewegung = false;
        zeitGesamt = 3;
        winkelGesamt = 90;
        zeitAnteilAlt = 0;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.C) && !bewegung)
        {
            bewegung = true;
            bewegungZeitStart = Time.time;
        }

        if (bewegung)
        {
            float zeitAnteil = (Time.time - bewegungZeitStart) / zeitGesamt;
            float winkelAenderung = (zeitAnteil - zeitAnteilAlt) * winkelGesamt;

            transform.RotateAround(new Vector3(-1.5f,0,1.5f),new Vector3(0, 1, 0), winkelAenderung);

            zeitAnteilAlt = zeitAnteil;
            Debug.Log(transform.eulerAngles.y);

            //if (zeitAnteil >= 1) bewegung = false;
            if (Input.GetKey(KeyCode.V)) bewegung = false;
        }
    }
}
