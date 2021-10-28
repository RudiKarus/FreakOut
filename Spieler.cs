using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spieler : MonoBehaviour
{
    public GameObject kamera;
    public GameObject gewinn;
    int punkte = 0;
    public Text punkteAnzeige;

    public GameObject explosionGewinn;

    public AudioClip gewinnHit;
    public AudioClip randHit;
    public AudioClip newGewinn;

    void Start()
    {
               
    }


    void Update()
    {
        kamera.transform.position = new Vector3(0,5.0f, transform.position.z-8.5f);
    }


    void OnCollisionStay(Collision coll)
    {
        if(coll.gameObject.tag=="Platte")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.001f, transform.position.z);
        }
    }


    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag=="Gewinn")
        {
            AudioSource.PlayClipAtPoint(gewinnHit, new Vector3(), 1.0f);
            Instantiate(explosionGewinn, transform.position, Quaternion.identity);
            punkte++;
            punkteAnzeige.text = "Points: " + punkte;
            gewinn.SetActive(false);
            Invoke("NaechsterGewinn", 1);
        }
    }

    void NaechsterGewinn()
    {
        AudioSource.PlayClipAtPoint(newGewinn, new Vector3(), 1.0f);
        gewinn.SetActive(true);
        gewinn.transform.localPosition = new Vector3(Random.Range(-3, 3), 0.657f, Random.Range(-3, 3));
        gewinn.GetComponent<Rigidbody>().AddTorque(13, 33, 9);
    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag=="Rand")
        {
            AudioSource.PlayClipAtPoint(randHit, new Vector3(), 1.0f);
            punkte--;
            punkteAnzeige.text = "Points: " + punkte;
        }
    }
}
