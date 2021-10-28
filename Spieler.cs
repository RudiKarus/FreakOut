using UnityEngine;
using UnityEngine.UI;

public class Spieler : MonoBehaviour
{
	public GameObject ziegelPrefab;
	public GameObject ball;
	public Ball ballKlasse;

	Rigidbody2D ballRB;
	public bool ballUnterwegs = false;
	float eingabeFaktor = 10;

	public Text punkteAnzeige;
	public Text lebenAnzeige;
	public Text infoAnzeige;
	public Text zeitAnzeige;
	public Text zeitAltAnzeige;

	public bool spielGestartet = false;
	public float spielZeitStart;


	void Start()
	{
		ballRB = ball.GetComponent<Rigidbody2D>();
		ZiegelErzeugen();
		ZeitAltLaden();
	}


	void ZiegelErzeugen()
	{
		for (int x = 1; x <= 10; x++)
		{
			for (int y = 1; y <= 5; y++)
			{
				Instantiate (ziegelPrefab, new Vector3 (x * 1.2f - 6.6f, y * 0.75f - 0.25f, 0), Quaternion.identity);
			}
		}
	}


	void ZeitAltLaden()
	{
		float zeitAlt = 0;
		if (PlayerPrefs.HasKey("zeitAlt"))
			zeitAlt = PlayerPrefs.GetFloat("zeitAlt");
		zeitAltAnzeige.text = string.Format("last round: {0,6:#0.0} sec.", zeitAlt);
	}


    void Update()
	{
		float xEingabe = Input.GetAxis("Horizontal");
		float yEingabe = Input.GetAxis("Vertical");

		if (!ballUnterwegs && yEingabe > 0)
		{
			ballRB.AddForce(new Vector2(300, 200));
			ballUnterwegs = true;

			if (!spielGestartet)
			{
				spielGestartet = true;
				spielZeitStart = Time.time;
			}
			infoAnzeige.text = "";
		}

		if (ballUnterwegs)
		{
			float xNeu = transform.position.x + xEingabe * eingabeFaktor * Time.deltaTime;
			if (xNeu < -6) xNeu = -6;
			if (xNeu > 6) xNeu = 6;
			transform.position = new Vector3(xNeu, transform.position.y, 0);
		}

		if (spielGestartet)
			zeitAnzeige.text = string.Format("Time: {0,6:##0.0} sec.", Time.time - spielZeitStart);
	}


    public void SpielNeuButton_Click()
	{
		if (spielGestartet)
			return;

		ballKlasse.anzahlPunkte = 0;
		ballKlasse.anzahlLeben = 5;

		punkteAnzeige.text = "Points: 0";
		lebenAnzeige.text = "Lifes: 5";
		zeitAnzeige.text = "Time:    0.0 sec.";
		infoAnzeige.text = "Shoot the ball with the up-arrow key.\n"
            + "Move the player with the left- and right-arrow keys.\n"
            + "Destroy the targets and hold on tight.";

		ZeitAltLaden();
		ZiegelErzeugen();
		AufStartpunkt();
	}


	public void AufStartpunkt()
	{
		gameObject.SetActive(true);
		transform.position = new Vector3(0, -4.55f, 0);

		ball.SetActive(true);
		ball.transform.position = new Vector3(0, -4.1f, 0);
	}


	public void AnwendungEndeButton_Click()
	{
		if (!spielGestartet || spielGestartet)
			Application.Quit();
	}
}
