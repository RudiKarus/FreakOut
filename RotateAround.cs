using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddTorque(0, 5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
