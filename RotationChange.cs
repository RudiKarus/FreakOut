using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationChange : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) GetComponent<Rigidbody>().AddTorque(0, 5, 0);
        if (Input.GetKeyDown(KeyCode.D)) GetComponent<Rigidbody>().AddTorque(0,-5, 0);

        if (Input.GetKeyDown(KeyCode.W)) GetComponent<Rigidbody>().AddTorque( 5, 0, 0);
        if (Input.GetKeyDown(KeyCode.S)) GetComponent<Rigidbody>().AddTorque(-5, 0, 0);
    }
}
