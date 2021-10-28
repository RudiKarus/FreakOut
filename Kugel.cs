using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Kugel : MonoBehaviour
{
    int[] loesung = new int[5];

    public Text aufgabeAnzeige;
    public Text kommentarAnzeige;
    public Text[] loesungAnzeige = new Text[5];
    int[] posIndex = new int[5];

    float eingabeFaktor = 10;
    float yStrecke = -2;
    int punkte = 0;
    public Text punkteAnzeige;
    bool bewegtSich = false;

    int leben = 5;
    public Text lebenAnzeige;

    public Material defaultMat;
    public Material rightMat;
    public Material wrongMat;
    public GameObject explosionWrong;
    public GameObject explosionRight;

    public AudioClip rightAnswer;
    public AudioClip wrongAnswer;
    public AudioClip gameOver;

    


    void Start()
    {
        AufgabeStellen();        
    }




    void AufgabeStellen()
    {
                                                                    //Aufgabe und richtige Loesung erzeugen;
        int a = Random.Range(1, 99);
        int b = Random.Range(1, 99);
        int aufgabenIndex = Random.Range(1, 3);                     //zufällige Aufgabenstellung ermitteln
        if (aufgabenIndex == 1)
        {
            loesung[0] = a + b;
            aufgabeAnzeige.text = a + " + " + b;
        }
        else
        {
            loesung[0] = a - b;
            aufgabeAnzeige.text = a + " - " + b;
        }

                                                                    //erste falsche Loesung erzeugen, +/- 10;
        int zz = Random.Range(1, 3);
        if (zz == 1)
        {
            loesung[1] = loesung[0] + 1;
        }
        else
        {
            loesung[1] = loesung[0] - 1;
        }

                                                                    //drei weitere falsche Loesungen generieren
        for (int i = 2; i < 5; i++)
        {
            bool vorhanden;

            do
            {
                loesung[i] = loesung[0] + Random.Range(-10, 10);
                vorhanden = false;

                for (int k = 0; k < i; k++)
                {
                    if (loesung[k] == loesung[i])
                    {
                        vorhanden = true;
                        break;
                    }
                }
            } while (vorhanden);

        }

      /*  //Kontrollausgabe;
        string kontrollAusgabe = "Quest: " + a + " + " + b + ", Solutions: ";
        for (int i = 0; i < 5; i++)
        {
            kontrollAusgabe = +loesung[i] + " ";
            Debug.Log(kontrollAusgabe);
        }*/


        kommentarAnzeige.text = "";

                                                                    //Anfangsposition der Loesung festlegen (1:1 patch)
        for (int i = 0; i < 5; i++)
        {
            posIndex[i] = i;
        }

                                                                    //Position der Loesung mischen (mithilfe eines "Ringtauschs");
        for (int i = 0; i < 20; i++)
        {
            a = Random.Range(0, 5);
            b = Random.Range(0, 5);
            int temp = posIndex[a];
            posIndex[a] = posIndex[b];
            posIndex[b] = temp;             //a erhaelt den Wert von b und b den zwischengespeicherten Wert(temp) von a. D.h: z.B: Position 1 wird Position 3 usw.;
        }

                                                                    //Loesung an gemischten Positionen anzeigen;
        for (int i = 0; i < 5; i++)
        {
            loesungAnzeige[posIndex[i]].text = "" + loesung[i];
        }


                                                                    //Kugel startet oben;
        transform.position = new Vector3(Random.Range(-7.5f,7.5f),12,0);
        GetComponent<MeshRenderer>().material = defaultMat;
        gameObject.SetActive(true);
        bewegtSich = true;
    }




    void Update()
    {
                                                                    //Kugel bewegt sich;
        if(bewegtSich)
        {
            transform.Translate(Input.GetAxis("Horizontal") * eingabeFaktor * Time.deltaTime, (yStrecke/2.0f)*Time.deltaTime, 0);
            if(Input.GetKey(KeyCode.Space))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y +(yStrecke*2.0f) *Time.deltaTime, 0);
            }

                                                                    //Kugel zwischen den Plattformen;
            if(transform.position.y < 0)
            {
                Fehler("MISSED! ");
            }
        }
    }




    void OnCollisionEnter(Collision coll)
    {
                                                                    //Nummer der Platform ermitteln;
        int plattformNummer = System.Convert.ToInt32(coll.gameObject.name.Substring(9, 1));
        
                                                                    //Richtige Loesung;
        if(plattformNummer == posIndex[0])
        {
            GetComponent<MeshRenderer>().material = rightMat;
            Instantiate(explosionRight, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(rightAnswer, new Vector3(), 1.0f);
            gameObject.SetActive(false);

            bewegtSich = false;
            yStrecke = yStrecke * 1.05f;
            kommentarAnzeige.text = "";
            punkte++;
            punkteAnzeige.text ="BrainGain: " +punkte;

            Invoke("AufgabeStellen", 2.0f);
        }
        else
        {
            Fehler("");
        }
    }




    void Fehler(string text)
    {
        GetComponent<MeshRenderer>().material = wrongMat;
        Instantiate(explosionWrong, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(wrongAnswer, new Vector3(), 0.5f);
        gameObject.SetActive(false);

        leben--;
        lebenAnzeige.text = "Life: " + leben;
        bewegtSich = false;

        if(leben > 0)
        {
            yStrecke *= 1.05f;
            kommentarAnzeige.text= text + "" + leben + " lifes left";
            if (leben == 1) kommentarAnzeige.text = text + " last life! ";

            Invoke("AufgabeStellen", 1.5f);
        }
        else
        {
            kommentarAnzeige.transform.localScale = new Vector3(2, 2, 2);
            kommentarAnzeige.text = "GAME OVER";
            AudioSource.PlayClipAtPoint(gameOver, new Vector3(), 1.0f);
        }
    }
}
