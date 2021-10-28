using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spieler : MonoBehaviour
{
    float inputSpeed = 10.5f;
    public GameObject gewinn;
    int anzahlPunkte = 0;
    public Text punkteAnzeige;
    int anzahlLeben = 3;
    public Text lebenAnzeige;
    float startZeit;
    bool spielGestartet = false;
    public Text zeitAnzeige;
    public Text zeitAltAnzeige;
    public Text infoAnzeige;



    void Start()
    {
        float zeitAlt = 0;
        if (PlayerPrefs.HasKey("zeitAlt"))
        {
            zeitAlt = PlayerPrefs.GetFloat("zeitAlt");
            zeitAltAnzeige.text = string.Format("Last round: {0, 6:0.0} sec.", zeitAlt); 
        }
    }



    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if (inputY < 0) { return; }

        float newX = transform.position.x + inputX * inputSpeed * Time.deltaTime;
        if (newX > 8.3f) { newX = 8.3f; }
        if (newX < -8.3f) { newX = -8.3f; }

        float newY = transform.position.y + inputY * inputSpeed * Time.deltaTime;
        if (newY > 4.5f) { newY = 4.5f; }

        transform.position = new Vector3(newX, newY, 0);



        if( !spielGestartet && (inputX !=0 || inputY != 0))
        {
            spielGestartet = true;
            startZeit = Time.time;
            infoAnzeige.text = "";
            Cursor.visible = false;
        }
        if (spielGestartet)
        {
            zeitAnzeige.text = string.Format("Time: {0, 6:0.0} sec.", Time.time-startZeit);
        }
    }

  

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Gewinn")
        {
            anzahlPunkte = anzahlPunkte + 1;
            gewinn.SetActive(false);
    
            if (anzahlPunkte < 6)
            {
                punkteAnzeige.text = "Points: " + anzahlPunkte;

                if (anzahlPunkte == 1)
                {
                    infoAnzeige.text = "You've got 1 Point!";
                }
                else
                {
                    infoAnzeige.text = "You've got " + anzahlPunkte + " Points ";
                }

             Invoke("NaechsterGewinn", 2);
            }
            else
            {
                gameObject.SetActive(false);
                gewinn.SetActive(false);
                infoAnzeige.text = "You WIN!";
                spielGestartet = false;
                Cursor.visible = true;

                PlayerPrefs.SetFloat("zeitAlt", Time.time - startZeit);
                PlayerPrefs.Save();
            }
            
            float newX = Random.Range(-8.0f, 8.0f);
            float newY;
            if (anzahlPunkte < 2)
            {
                newY = -2.7f;
            }
            else if (anzahlPunkte < 4)
            {
                newY = 0.15f;
            }
            else
            {
                newY = 3;
            }

            gewinn.transform.position = new Vector3(newX, newY, 0);
        }



        else if (coll.gameObject.tag == "Gefahren")
        {
            anzahlLeben = anzahlLeben - 1;
            lebenAnzeige.text = "Lives: " + anzahlLeben;

            gameObject.SetActive(false);

            if (anzahlLeben > 1)
            {
                infoAnzeige.text = "You've got " + anzahlLeben + " lives left !";
                Invoke("NaechstesLeben", 2);

            }

            else if (anzahlLeben == 1)
            {
                infoAnzeige.text = "last live !!!";
                Invoke("NaechstesLeben", 2);
            }

            else
            {
                gewinn.SetActive(false);
                infoAnzeige.text = "You LOOSE!";
                spielGestartet = false;
                Cursor.visible = true;
            }
        }
    }



    void NaechsterGewinn()
    {
        float newX = Random.Range(-8.0f, 8.0f);

        float newY;
        if (anzahlPunkte < 2)
        {
            newY = -2.7f;
        }
        else if (anzahlPunkte < 4)
        {
            newY = 0.15f;
        }
        else
        {
            newY = 3;
        }

        gewinn.transform.position = new Vector3(newX, newY, 0);
        gewinn.SetActive(true);
        infoAnzeige.text = "";
    }



    void NaechstesLeben()
    {
        float newX = Random.Range(-8.0f, 8.0f);
        float newY = Random.Range(-4.8f, 4.8f);

        transform.position = new Vector3(newX, newY, 0);
        gameObject.SetActive(true);
        infoAnzeige.text = "";
    }



    public void SpielNeuButton_Click()
    {
        if (spielGestartet)
        {
            return;
        }

        anzahlPunkte = 0;
        anzahlLeben = 3;
        float zeitAlt = 0;
        if (PlayerPrefs.HasKey("zeitAlt"))
        {
            zeitAlt = PlayerPrefs.GetFloat("zeitAlt");
        }

        punkteAnzeige.text = "Points: 0";
        lebenAnzeige.text = "Lives: 3";
        zeitAnzeige.text = "Time: 0.0 sec.";
        zeitAltAnzeige.text = string.Format( "Last round: {0, 6:0.0} sec.", zeitAlt);
        infoAnzeige.text = "Press any key to start.\n"
            + "Use the arrow keys to control your player.\n"
            + "Collect yellow points and avoid the magenta colored bars.\n"
            + "Have fun ;)";

        transform.position = new Vector3(0, -4.4f, 0);
        gameObject.SetActive(true);

        gewinn.transform.position = new Vector3(4, -2.7f, 0);
        gewinn.SetActive(true);
    }



    public void AnwendungEndeButton_Click()
    {
        if (!spielGestartet || spielGestartet)
        {
            Application.Quit();
        }
    }
}