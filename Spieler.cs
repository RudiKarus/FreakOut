using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spieler : MonoBehaviour
{
    float eingabeFaktor = 10;
    public GameObject[] geschoss = new GameObject[22];

    public GefahrGewinn gefahrGewinnKlasse;
    int energie = 10;
    public GameObject balkenWert;

    public GameObject[] gefahr = new GameObject[3];
    public GameObject gewinn;
    float zeitStart;
    bool spielGestartet = true;
    public Text zeitAnzeige;
    public Text infoAnzeige;

    public AudioClip shot;
    public AudioClip enemyHit;
    public AudioClip friendHit;
    public AudioClip winner;
    public AudioClip looser;

    public GameObject winnerScreen;
    public GameObject backGround;
    public GameObject spieler;


    void Start()
    {
        zeitStart = Time.time;
    }


    void Update()
    {
        if(spielGestartet)
        {
            zeitAnzeige.text = string.Format("Time: {0,6:0.0} days", Time.time - zeitStart);
        }


        float yEingabe = Input.GetAxis("Vertical");
        float yNeu = transform.position.y + yEingabe * eingabeFaktor * Time.deltaTime;
        if (yNeu > 4.75f) yNeu = 4.75f;
        else if (yNeu < -4.75f) yNeu = -4.75f;

        float xEingabe = Input.GetAxis("Horizontal");
        float xNeu = transform.position.x + xEingabe * eingabeFaktor * Time.deltaTime;
        if (xNeu < -8.2f) xNeu = -8.2f;
        if (xNeu > 8.0f) xNeu = 8.0f;

        transform.position = new Vector3(xNeu, yNeu, 0);


        if (spielGestartet)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                for (int i = 0; i < 22; i++)
                {
                    if (!geschoss[i].activeSelf)
                    {
                        geschoss[i].SetActive(true);
                        geschoss[i].transform.position = new Vector3(transform.position.x + 0.7f, transform.position.y, 0);
                        AudioSource.PlayClipAtPoint(shot, new Vector3(), 1.0f);
                        break;
                    }
                }
            }
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        coll.gameObject.transform.position = new Vector3(Random.Range(9.5f, 19.0f), Random.Range(-4.75f, 4.75f), 0);
        gefahrGewinnKlasse.xStartPunkt *= 1.01f;

        if(coll.gameObject.tag=="Gefahr")
        {
            AudioSource.PlayClipAtPoint(enemyHit, new Vector3(), 1.0f);
            EnergieAnzeige(-1);
        }
        else if (coll.gameObject.tag=="Gewinn")
        {
            AudioSource.PlayClipAtPoint(friendHit, new Vector3(), 1.0f);
            EnergieAnzeige(1);
        }
    }


    public void EnergieAnzeige(int wert)
    {
        energie = energie + wert;
        balkenWert.transform.localScale = new Vector3(0.8f, energie / 2.0f, 0);

        if (energie > 40)
        {
            AudioSource.PlayClipAtPoint(winner, new Vector3(), 1.0f);
            Instantiate(winnerScreen, new Vector3 (0,0,0), Quaternion.identity);
            backGround.SetActive(false);
            EndeSpiel("WINNER!");
        }
        if (energie < 1)
        {
            AudioSource.PlayClipAtPoint(looser, new Vector3(), 1.0f);
            spieler.SetActive(false);
            EndeSpiel(" you \n are \n DEAD");
        }
    }


    void EndeSpiel(string text)
    {
        spielGestartet = false;
        infoAnzeige.text ="" +text;

        for(int i=0;i<3;i++)
        {
            gefahr[i].SetActive(false);
        }
        for(int j=0;j<22;j++)
        {
            geschoss[j].SetActive(false);
        }
        gewinn.SetActive(false);

    }
}
