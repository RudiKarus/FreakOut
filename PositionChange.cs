using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    bool bewegung;
    float zeitGesamt;
    float bewegungZeitStart;
    Vector3 startPunkt;
    Vector3 zielPunkt;
    Vector3 streckeGesamt;

    
    void Start()
    {
        bewegung = false;
        zeitGesamt = 5;

        startPunkt = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        zielPunkt = new Vector3(transform.position.x, transform.position.y+3, transform.position.z);
        streckeGesamt = zielPunkt - startPunkt;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !bewegung)
        {
            bewegung = true;
            bewegungZeitStart = Time.time;
        }

        if(bewegung)
        {
            float zeitAnteil = (Time.time - bewegungZeitStart) / zeitGesamt;
            Vector3 streckenAnteil = zeitAnteil * streckeGesamt;
            transform.position = startPunkt + streckenAnteil;

            if (zeitAnteil >= 1)
            {
                bewegung = false;
            }
        }
    }
}
