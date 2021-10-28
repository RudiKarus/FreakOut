using System.Collections;
using System.Collections.Generic;       //zur Nutzung der generischen Datentypen;
using UnityEngine;
using UnityEngine.UI;

public class WuerfelNeu : MonoBehaviour
{
    public GameObject wuerfelPrefab;
    List<GameObject> wuerfelListe;
    Rigidbody rb;
    bool ende = false;

    int punkte = 0;
    public Text punkteAnzeige;

    public AudioClip wuerfelMove;
    public AudioClip wuerfelLandet;
    public AudioClip listeVoll;
    public AudioClip gameOver;

    public Text infoAnzeige;

    void Start()
    {
        wuerfelListe = new List<GameObject>();
        rb = GetComponent<Rigidbody>();

        Invoke("SpielGestartet", 6.0f);
    }

    void SpielGestartet()
    {
        infoAnzeige.text = "";
    }

    void Update()
    {        
        if (ende) return;


        float xNeu = transform.position.x;
        float zNeu = transform.position.z;
        float yNeu = transform.position.y;
        float eingabeFaktor = -7;


        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            xNeu++;                                // eine einmalige Aenderung um +1 wird erzeugt, Time.deltaTime wird nicht benoetigt fuer diese Bewegung da keine Bewegung in Abhaengigkeit des Bildaufbaus erforderlich ist;
            if (xNeu > 2) xNeu = 2;
            AudioSource.PlayClipAtPoint(wuerfelMove, new Vector3(), 0.5f);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xNeu--;
            if (xNeu < -2) xNeu = -2;
            AudioSource.PlayClipAtPoint(wuerfelMove, new Vector3(), 0.5f);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            zNeu++;
            if (zNeu > 2) zNeu = 2;
            AudioSource.PlayClipAtPoint(wuerfelMove, new Vector3(), 0.5f);
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            zNeu--;
            if (zNeu < -2) zNeu = -2;
            AudioSource.PlayClipAtPoint(wuerfelMove, new Vector3(), 0.5f);
        }
        if (Input.GetKey(KeyCode.Space)) yNeu = transform.position.y + eingabeFaktor*Time.deltaTime;


        transform.position = new Vector3(xNeu, yNeu, zNeu);
    }


    void OnCollisionEnter(Collision coll)
    {
        Vector3 positionGelandet = transform.position;
        AudioSource.PlayClipAtPoint(wuerfelLandet, new Vector3(), 0.5f);

        if (positionGelandet.y < 4)
        {
            //rb.useGravity = false;
            Object wuerfelGelandet = Instantiate(wuerfelPrefab, positionGelandet, Quaternion.identity);     //das gelandete prefab wird an aktueller Position instanziiert;
            GameObject neuerWuerfel = (GameObject)wuerfelGelandet;      //die erzeugte Instanz wird zum neuen GameObject konvertiert 
            wuerfelListe.Add(neuerWuerfel);     //das neue GameObject wird der Liste List<GameObject> hinzugefuegt;

            transform.position = new Vector3(0, 6, 0);      //das GameObject Wuerfel wird wieder an die Startposition gesetzt
            rb.drag = rb.drag * 0.98f;

            Pruefen();
        }
        else
        {
            ende = true;
            AudioSource.PlayClipAtPoint(gameOver, new Vector3(), 1.0f);
        }
    }

    void Pruefen()
    {
        int zaehler = 0;

        for(int k=0; k < wuerfelListe.Count; k++)       //die Anzahl der enthaltenen Elemente in der Liste werden durchlaufen
        {
            if(wuerfelListe[k].transform.position.y >= -2.75f && wuerfelListe[k].transform.position.y <= -2.35f)        //jedes enthaltene Element wird auf die richtige Position (auf der Platte) ueberprueft;
            zaehler++;
        }

        if(zaehler==25)
        {
            punkte++;
            punkteAnzeige.text = "Points: " + punkte;

            for(int k= wuerfelListe.Count-1; k>= 0; k--)    //die Zaehlrichtung ist hier rueckwaerts, da beim entfernen aus der Liste nachfolgende Elemente nachruecken und somit bei einer forwaertszaehlrichtung uebersprungen werden wuerden;
            {
                if (wuerfelListe[k].transform.position.y >= -2.75f && wuerfelListe[k].transform.position.y <= -2.35f)
                {
                    Destroy(wuerfelListe[k]);   //die GameObjects werden zerstoert und
                    wuerfelListe.RemoveAt(k);   //aus der Liste entfernt;
                }
            }

            AudioSource.PlayClipAtPoint(listeVoll, new Vector3(), 1.0f);
        }
    }
}
