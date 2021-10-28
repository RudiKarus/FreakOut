using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gewinn : MonoBehaviour
{
    

    void Start()
    {
        GetComponent<Rigidbody>().AddTorque(13, 33, 9);    
    }

    void Update()
    {
        
    }
}
