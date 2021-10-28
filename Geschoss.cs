using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geschoss : MonoBehaviour
{
    public GefahrGewinn gefahrGewinnKlasse;
    public Spieler spielerKlasse;
    public GameObject explosionRot;
    public GameObject explosionGruen;

    public AudioClip enemyExplode;
    public AudioClip friendExplode;


    void Start()
    {
        
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y, 0);
        
        if(transform.position.x > 8.5f)
        {
            gameObject.SetActive(false);
            transform.position = new Vector3(-9.5f, 0, 0);            
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Gefahr")
        {
            Instantiate(explosionRot, transform.position, Quaternion.identity);
            spielerKlasse.EnergieAnzeige(1);

            AudioSource.PlayClipAtPoint(enemyExplode, new Vector3(), 1.0f);
        }
        else if (coll.gameObject.tag == "Gewinn")
        {
            Instantiate(explosionGruen, transform.position, Quaternion.identity);
            spielerKlasse.EnergieAnzeige(-1);

            AudioSource.PlayClipAtPoint(friendExplode, new Vector3(), 1.0f);
        }

        if (coll.gameObject.tag == "Gefahr" || coll.gameObject.tag == "Gewinn")
        {
            gameObject.SetActive(false);
            transform.position = new Vector3(-10.5f, 0, 0);
            coll.gameObject.transform.position = new Vector3(Random.Range(9.5f, 19.0f), Random.Range(-4.5f, 4.5f), 0);

            gefahrGewinnKlasse.xStartPunkt *= 1.01f;
        }
    }
}
