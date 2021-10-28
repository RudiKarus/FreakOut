using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platte : MonoBehaviour
{
    float eingabeFaktor = 20;
    float grenzWinkel = 7.5f;

    public Text xWinkelAnzeige;
    public Text zWinkelAnzeige;

    public Text infoAnzeige;
    bool spielGestartet = false;

    void Start()
    {
        infoAnzeige.text = "Use the [Arrow-Keys]";
    }


    void Update()
    {
        float zEingabe = Input.GetAxis("Horizontal");
        float xEingabe = Input.GetAxis("Vertical");

        if ((xEingabe>0 || zEingabe>0) || (xEingabe<0 || zEingabe<0))
        {
            spielGestartet = true;
        }
        if (spielGestartet)
        {
            infoAnzeige.text = "";
        }

        float zWinkelNeu = transform.eulerAngles.z - zEingabe * eingabeFaktor * Time.deltaTime; ;
        if(zWinkelNeu>=0 && zWinkelNeu<180 && zWinkelNeu>grenzWinkel)
        {
            zWinkelNeu = grenzWinkel;
        }
        if(zWinkelNeu>=180 && zWinkelNeu<360 && zWinkelNeu<360-grenzWinkel)
        {
            zWinkelNeu = 360 - grenzWinkel;
        }
        
        float xWinkelNeu = transform.eulerAngles.x + xEingabe * eingabeFaktor * Time.deltaTime;
        if(xWinkelNeu>=0 && xWinkelNeu<180 && xWinkelNeu>grenzWinkel)
        {
            xWinkelNeu = grenzWinkel;
        }
        if(xWinkelNeu>=180 && xWinkelNeu<360 && xWinkelNeu<360-grenzWinkel)
        {
            xWinkelNeu = 360 - grenzWinkel;
        }


        transform.eulerAngles = new Vector3(xWinkelNeu, 0, zWinkelNeu);
        xWinkelAnzeige.text = string.Format("x Angle: {0,6:0.0} ", xWinkelNeu);
        zWinkelAnzeige.text = string.Format("z Angle: {0,6:0.0}", zWinkelNeu);
    }
}
