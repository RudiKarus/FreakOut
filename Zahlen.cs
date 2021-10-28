using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Zahlen : MonoBehaviour
{
    static int erwartet = 0;
    public Training training;

    public AudioClip GoAhead;
    public AudioClip GoBack;


    void Start()
    {
        
    }


    void Update()
    {
        
    }


    public void Button_Click()
    {
        if (!training.buttonsKlickbar)
            return;

        int geklickt = Convert.ToInt32(gameObject.name.Substring(4, 1));

        if(geklickt == erwartet)
        {
            AudioSource.PlayClipAtPoint(GoAhead, new Vector3(), 0.5f);
            gameObject.GetComponentInChildren<Text>().text = geklickt+"";
            if(erwartet == training.zahlMax)
            {
                erwartet = 0;
                training.Vorwaerts();
            }
            else erwartet++;
        }
        else
        {
            gameObject.GetComponentInChildren<Text>().text = "X";
            AudioSource.PlayClipAtPoint(GoBack, new Vector3(),1.0f);
            training.Zurueck();
            erwartet = 0;
        }
    }
}
