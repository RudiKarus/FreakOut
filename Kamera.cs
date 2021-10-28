using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public GameObject fahrzeug;
    float abstandXZ = 3.0f;
    float hoeheY = 1.0f;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        Quaternion fahrzeugRotationY = new Quaternion();        //Erzeugung eines leeren Drehungsobjekts
        fahrzeugRotationY.eulerAngles = new Vector3(0, fahrzeug.transform.eulerAngles.y, 0);        //Zuweisung der Drehungswerte von dem GameObject Fahrzeug
        Vector3 abstandHinterFahrzeug = fahrzeugRotationY * new Vector3(0, 0, abstandXZ);       //Berechnung des Punktes für die Kamera
        transform.position = fahrzeug.transform.position - abstandHinterFahrzeug;       //Kamera wird auf den berechneten Punkt gesetzt
        transform.position = new Vector3(transform.position.x, transform.position.y + hoeheY, transform.position.z);        //die Kamera wird hoch gesetzt
        transform.LookAt(fahrzeug.transform);       //die Kamera wird aufs Fahrzeug gerichtet
    }
}
