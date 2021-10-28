using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fahrer : MonoBehaviour
{
    bool rundenZaehlenErlaubt = true;
    bool inBereich = false;
    int runde = 0;

    float[] rundenzeitStart = new float[3];
    public Text[] rundenzeitAnzeige = new Text[3];

    public Countdown countdownKlasse;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (rundenZaehlenErlaubt)
        {

            if (transform.position.x > 20 && transform.position.x < 30)
            {
                if (transform.position.z > 12 && transform.position.z < 12.5f)
                {
                    inBereich = true;
                }
                else if (inBereich && transform.position.z > 12.5f && transform.position.z < 13)
                {
                    runde++;
                    if(runde == 1)
                    {
                        rundenzeitStart[0] = countdownKlasse.zeitStartGesamt;
                    }
                    else if (runde < 4)
                    {
                        rundenzeitStart[runde - 1] = Time.time;
                    }
                    Debug.Log(runde);
                    inBereich = false;
                    rundenZaehlenErlaubt = false;
                    Invoke("RundenZaehlenErlauben", 20);
                }
            }
        }
        if(runde == 0)
        {
            if (countdownKlasse.zeitStartGesamt > 0)
            {
                rundenzeitAnzeige[0].text = string.Format("Round {0,2:0}: {1,6:0.0} sec.", 0, Time.time - countdownKlasse.zeitStartGesamt);
            }
        }
        else if (runde < 4)
        {
            rundenzeitAnzeige[runde - 1].text = string.Format("Round{0,2:0}: {1,6:0.0} sec.", runde, Time.time - rundenzeitStart[runde-1]);
        }
    }

    void RundenZaehlenErlauben()
    {
        rundenZaehlenErlaubt = true;
    }
}
