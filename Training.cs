using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Training : MonoBehaviour
{
    public GameObject[] Zahl = new GameObject[10];
    public int zahlMax;
    int zahlMaxGrenze = 9;
    public bool buttonsKlickbar = false;

    public Text infoAnzeige;

    public AudioClip Win;


    void Start()
    {
        zahlMax = 2;
        infoAnzeige.text = "REMEMBER THE POSITION \n and uncover the cards in the right order.";
        Invoke("ButtonsVerteilen", 3);
    }


    void Update()
    {
        
    }


    void ButtonsVerteilen()
    {
        bool positionDoppelt;
        Vector3 positionNeu;

        for(int i=0; i<=zahlMax; i++)
        {
            do
            {
                positionNeu = new Vector3(Random.Range(1, 26) * 50 - 25, Random.Range(1, 15) * 50 - 25, 0);

                positionDoppelt = false;

                for(int k=0; k<i; k++)
                {
                    if((Zahl[k].GetComponent<RectTransform>().position - positionNeu).magnitude<25)
                    {
                        positionDoppelt = true;
                        break;
                    }
                }

            } while (positionDoppelt);

            Zahl[i].GetComponent<RectTransform>().position = positionNeu;
        }

        for (int i =0; i<=9; i++)
        {
            if (i <= zahlMax)
            {
                Zahl[i].SetActive(true);
                Zahl[i].GetComponentInChildren<Text>().text = i + "";
            }
            else
            {
                Zahl[i].SetActive(false);
            }
        }

        if (zahlMax <= 7) Invoke("ZahlenLoeschen", (zahlMax * 1.5f));
        else Invoke("ZahlenLoeschen", (zahlMax * 2.5f));
    }


    void ZahlenLoeschen()
    {
        for (int i = 0; i <= zahlMax; i++)
        {
            Zahl[i].GetComponentInChildren<Text>().text = "";
        }
        // infoAnzeige.text = "Click on one card after another";
        buttonsKlickbar = true;
    }


    public void Vorwaerts()
    {
        zahlMax++;
        buttonsKlickbar = false;

        if(zahlMax>zahlMaxGrenze)
        {
            infoAnzeige.text = "You reached the limit! \n Good Chimp!";
            AudioSource.PlayClipAtPoint(Win, new Vector3());
        }
        else
        {
            infoAnzeige.text = "DONE \n Go ahead with " + (zahlMax + 1) + " cards";
            Invoke("Weiter", 3);
        }
    }
      

    public void Weiter()
    {
        ButtonsVerteilen();
        infoAnzeige.text = "";
    }


    public void Zurueck()
    {
        zahlMax--;
        buttonsKlickbar = false;
       // infoAnzeige.text = "Wrong! \n Go back to "+ (zahlMax+1)+ " cards.";
        if (zahlMax == 0) infoAnzeige.text = "Well, try it with " + (zahlMax + 1) + " card!";
        Invoke("Weiter", 2);
    }
}
