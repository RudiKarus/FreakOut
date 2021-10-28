using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kopf : MonoBehaviour
{
    Rigidbody rb;
    List<GameObject> segmentListe;
    int punkte;
    public Text punkteAnzeige;

    float zeitStart;
    bool spielGestartet;
    public Text zeitAnzeige;
    public Text infoAnzeige;

    public AudioClip moveSound;
    public AudioClip targetSound;
    public AudioClip wallSound;

    public GameObject explosion;
    public GameObject schlangeTot;


    void Start()
    {
        spielGestartet = true;
        zeitStart = Time.time;
        Invoke("InfoAnzeigeStart", 0.0f);
        Invoke("InfoAnzeigeSpiel", 5.0f);

        rb = GetComponent<Rigidbody>();        

        segmentListe = new List<GameObject>();
        segmentListe.Add(GameObject.Find("Kopf"));
        for(int i=1; i<=10; i++)
        {
            segmentListe.Add(GameObject.Find("Capsule"+i));
        }
    }
    void InfoAnzeigeStart()
    {
        infoAnzeige.text = "use the arrow-keys...";
    }
    void InfoAnzeigeSpiel()
    {
        infoAnzeige.text = "";
    }

    
    void Update()
    {
        if (spielGestartet == true)
        {


            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.AddForce(0, 0, 400);
                //transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z + 1);
                AudioSource.PlayClipAtPoint(moveSound, new Vector3(), 0.5f);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb.AddForce(0, 0, -400);
                AudioSource.PlayClipAtPoint(moveSound, new Vector3(), 0.5f);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                rb.AddForce(400, 0, 0);
                AudioSource.PlayClipAtPoint(moveSound, new Vector3(), 0.5f);
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                rb.AddForce(-400, 0, 0);
                AudioSource.PlayClipAtPoint(moveSound, new Vector3(), 0.5f);
            }

            if (spielGestartet)
            {
                zeitAnzeige.text = string.Format("Time: {0,6:0.0} sec.", Time.time - zeitStart);
            }
        }
    }


    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Ziel")
        {
            AudioSource.PlayClipAtPoint(targetSound, new Vector3(), 1.0f);
            Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            punkte++;
            punkteAnzeige.text = "Points: " + punkte +" /10";

            if (punkte >= 10)
            {
                spielGestartet = false;
                Destroy(GameObject.Find("Capsule1"));
                Destroy(GameObject.Find("Kopf"));
                infoAnzeige.text = "YOU WIN!";
            }

            Vector3 positionAlt = coll.gameObject.transform.position;
            Vector3 positionNeu;
            do
            {
                positionNeu = new Vector3(Random.Range(-4.0f, 4.0f), 0.2f, Random.Range(-4.0f, 4.0f));
            }
            while ((positionNeu - positionAlt).magnitude < 3);

            coll.gameObject.transform.position = positionNeu;

            if(segmentListe.Count >= 2)      //zum entfernen der Elemente bzw. kürzen der Schlange;
            {
                Destroy(segmentListe[segmentListe.Count - 2].GetComponent<HingeJoint>());
                Destroy(segmentListe[segmentListe.Count - 1]);
                segmentListe.RemoveAt(segmentListe.Count - 1);      //zum entfernen des letzten Listenelements;
            }
            if(punkte==-1)
            {
                Destroy(GameObject.Find("Kopf"));
                spielGestartet = false;
                infoAnzeige.text = "You LOOSE";
            }
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Rand")
        {
            AudioSource.PlayClipAtPoint(wallSound, new Vector3(), 1.0f);
            //RandGetroffen();
            infoAnzeige.text = "GAME OVER";
            Instantiate(schlangeTot, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            spielGestartet = false;
        }
    }

    public void RandGetroffen()
    {
        punkte--;
        punkteAnzeige.text = "Points: " + punkte + " /10";
    }
}
