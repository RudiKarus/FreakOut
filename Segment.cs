using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segment : MonoBehaviour
{
    public Kopf kopfKlasse;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Rand")
        {
            kopfKlasse.RandGetroffen();
        }
    }
}
