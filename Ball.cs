using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
	public GameObject spieler;
	public Spieler spielerKlasse;
	public AudioClip kollisionZiegelAudio;
	Rigidbody2D rb;

	public int anzahlPunkte = 0;
	public int anzahlLeben = 5;

	public Text punkteAnzeige;
	public Text lebenAnzeige;
	public Text infoAnzeige;


	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}


    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D coll)
	{
		GameObject anderesObjekt = coll.gameObject;

		if (anderesObjekt.tag == "Ziegel")
		{
			AudioSource.PlayClipAtPoint (kollisionZiegelAudio, transform.position);
			anzahlPunkte++;
			punkteAnzeige.text = "Points: " + anzahlPunkte;

			if (anzahlPunkte < 50)
			{
				Destroy (anderesObjekt, 0.1f);
				if (anzahlPunkte % 10 == 0)
					rb.velocity = new Vector2 (rb.velocity.x * 1.15f, rb.velocity.y * 1.15f);
				Debug.Log ("Points: " + anzahlPunkte + " Speed: " + rb.velocity.magnitude); 
			}
			else
			{
				Destroy (anderesObjekt);
				spieler.SetActive (false);
				gameObject.SetActive (false);

				float spielZeitAktuell = Time.time - spielerKlasse.spielZeitStart;
				infoAnzeige.text = string.Format ("You WIN, in {0,6:##0.0} sec.", spielZeitAktuell);
				spielerKlasse.spielGestartet = false;

                PlayerPrefs.SetFloat("zeitAlt", spielZeitAktuell);
                PlayerPrefs.Save();
               
			}
		}
		else if (anderesObjekt.tag == "BodenMitte")
		{
			anzahlLeben--;
			lebenAnzeige.text = "Lifes: " + anzahlLeben;

			spieler.SetActive (false);
			gameObject.SetActive (false);
			spielerKlasse.ballUnterwegs = false;

			if (anzahlLeben >= 1)
			{
				Invoke ("NaechstesLeben", 1);
				infoAnzeige.text = " " + anzahlLeben + " lifes left!";
                if (anzahlLeben==1)
                {
                    Invoke("NaechstesLeben", 1);
                    infoAnzeige.text = "Last chance!";
                }
			}
			else
			{
				infoAnzeige.text = "You LOOSE!"; 
				spielerKlasse.spielGestartet = false;
			}
		}
	}


	void NaechstesLeben()
	{
		infoAnzeige.text = "";
		spielerKlasse.AufStartpunkt();
	}
}