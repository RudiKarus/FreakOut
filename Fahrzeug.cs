using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fahrzeug : MonoBehaviour
{
    float drehmomentFaktor = 30000;
    public WheelCollider collVL, collVR, collHL, collHR;

    float lenkwinkelFaktor = 40;
    public GameObject radVL, radVR;

    public Countdown countdownKlasse;


    void Start()
    {
        
    }


    void Update()
    {
        if (countdownKlasse.zeitStartGesamt <= 0)
        {
            return;
        }
            float drehmoment;
            if (gameObject.name == "FahrzeugEins")
            {
                drehmoment = drehmomentFaktor * Time.deltaTime * Input.GetAxis("Fire1");
            }
            else
            {
                drehmoment = drehmomentFaktor * Time.deltaTime * Input.GetAxis("Vertical");
            }
            collVL.motorTorque = drehmoment;
            collVR.motorTorque = drehmoment;
            collHL.motorTorque = drehmoment;
            collHR.motorTorque = drehmoment;

            float lenkwinkel;
            if (gameObject.name == "FahrzeugEins")
            {
                lenkwinkel = lenkwinkelFaktor * Input.GetAxis("Fire2");
            }
            else
            {
                lenkwinkel = lenkwinkelFaktor * Input.GetAxis("Horizontal");
            }
            collVL.steerAngle = lenkwinkel;
            collVR.steerAngle = lenkwinkel;
            radVL.transform.localEulerAngles = new Vector3(radVL.transform.localEulerAngles.x, collVL.steerAngle, radVL.transform.localEulerAngles.z);
            radVR.transform.localEulerAngles = new Vector3(radVR.transform.localEulerAngles.x, collVR.steerAngle, radVR.transform.localEulerAngles.z);
    }
}
