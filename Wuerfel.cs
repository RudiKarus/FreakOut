using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public class Wuerfel : MonoBehaviour
{
    public GameObject wuerfelPrefab;
    List<GameObject> wuerfelListe;
    Rigidbody rb;
    bool ende = false;

    int punkte = 0;
    public Text punkteAnzeige;

    public AudioClip wuerfelMove;
    public AudioClip wuerfelLandung;
    public AudioClip ebeneVoll;
    public AudioClip gameOver;

    /*public GameObject wuerfelW;
    public GameObject wuerfelC;
    public GameObject wuerfelM;
    public GameObject wuerfelY;
    int wuerfelIndex;*/


    void Start()
    {
        wuerfelListe = new List<GameObject>();
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (ende==true) return;

        float xNeu = transform.position.x;  //Speichern der alten x und z positionen;
        float zNeu = transform.position.z;
        float yNeu = transform.position.y;

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            xNeu++; // erhoeht den Wert um 1. Dies ist eine einmalige Bewegung, keine fortlaufende und daher wird Time.deltaTime nicht benoetigt;
            if (xNeu > 2) xNeu = 2;

            AudioSource.PlayClipAtPoint(wuerfelMove, new Vector3(), 1.0f);
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xNeu--;
            if (xNeu < -2) xNeu = -2;

            AudioSource.PlayClipAtPoint(wuerfelMove, new Vector3(), 1.0f);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            zNeu++;
            if (zNeu > 2) zNeu = 2;

            AudioSource.PlayClipAtPoint(wuerfelMove, new Vector3(), 1.0f);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            zNeu--;
            if (zNeu < -2) zNeu = -2;

            AudioSource.PlayClipAtPoint(wuerfelMove, new Vector3(), 1.0f);
        }
        else if(Input.GetKey(KeyCode.Space))
        {
            yNeu = transform.position.y -10 *Time.deltaTime;
        }

        transform.position = new Vector3(xNeu, yNeu, zNeu);
    }


    void OnCollisionEnter(Collision coll)
    {
            Vector3 positionGelandet = transform.position;

            if (positionGelandet.y < 4 )
            {
                Object neuesObjekt = Instantiate(wuerfelPrefab, positionGelandet, Quaternion.identity);     // ein neues Object (Wuerfel) wird an der Landeposition des WuerfelPrefabs erzeugt;
                GameObject spielNeuesObjekt = (GameObject)neuesObjekt;      // der neu erzeugte Wuerfel wird in ein GameObject konvertiert;
                wuerfelListe.Add(spielNeuesObjekt);     // das konvertierte GameObject wird zur Liste hinzugefügt;

                transform.position = new Vector3(0, 6, 0); // das WuerfelPrefab wird zurueck an die Starposition gesetzt;
                rb.drag = rb.drag * 0.98f;
            }
            else
            { 
                ende = true;
                AudioSource.PlayClipAtPoint(gameOver, new Vector3(), 1.0f);
                gameObject.SetActive(false);
            }   

            if (positionGelandet.y < 4)
            {
                Pruefen();
            }  
    }
    

    void Pruefen()
    {
        int zaehler = 0;

        for(int k = 0; k < wuerfelListe.Count; k++)
        {
            if(wuerfelListe[k].transform.position.y > -2.75f && wuerfelListe[k].transform.position.y < -2.35f)
            {
                zaehler++;
            }
        }

        
        if (zaehler == 25)
        {
            punkte++;
            punkteAnzeige.text = "Points: " + punkte;
            AudioSource.PlayClipAtPoint(ebeneVoll, new Vector3(), 1.0f);

            for (int k = wuerfelListe.Count - 1; k >= 0; k--)
            {
                if(wuerfelListe[k].transform.position.y > -2.75f && wuerfelListe[k].transform.position.y < -2.35f)
                {
                    Destroy(wuerfelListe[k]);
                    wuerfelListe.RemoveAt(k);
                }
            }
        }

        if (zaehler < 25) AudioSource.PlayClipAtPoint(wuerfelLandung, new Vector3(), 1.0f);
    }
}
