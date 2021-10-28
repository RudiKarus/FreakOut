using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public int countdown = 5;
    public Text countdownAnzeige;
    public float zeitStartGesamt = 0;

    // Start is called before the first frame update
    void Start()
    {
        countdownAnzeige.text = "" + countdown;
        Invoke("HerunterZaehlen",1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void HerunterZaehlen()
    {
        countdown--;
        countdownAnzeige.text = "" + countdown;
        if(countdown>=1)
        {
            Invoke("HerunterZaehlen", 1);
        }
        else
        {
            zeitStartGesamt = Time.time;
            countdownAnzeige.text = "GO!";
            Invoke("Ausblenden", 3);
        }
    }


    void Ausblenden()
    {
        countdownAnzeige.text = "";
    }
}
