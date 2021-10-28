using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GefahrGewinn : MonoBehaviour
{
    public float xStartPunkt;
    float xBewegung;
    public Spieler spielerKlasse;
    public AudioClip enemyHit;

    void Start()
    {
        xStartPunkt = 2.2f * Time.deltaTime;
        xBewegung = 2.2f * Time.deltaTime;
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x - xBewegung, transform.position.y, 0);

        if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(Random.Range(9.5f, 19.0f), Random.Range(-4.75f, 4.75f), 0);
            xStartPunkt *= 1.01f;
            xBewegung = xStartPunkt * Random.Range(0.7f, 1.3f);

            if (gameObject.tag == "Gefahr")
            {
                spielerKlasse.EnergieAnzeige(-1);
                AudioSource.PlayClipAtPoint(enemyHit, new Vector3(), 1.0f);
            }
        }
    }
}