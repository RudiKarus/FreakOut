using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material cMat;
    public Material mMat;
    public Material yMat;

  
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) GetComponent<MeshRenderer>().material = cMat;
        if (Input.GetKeyDown(KeyCode.Alpha2)) GetComponent<MeshRenderer>().material = mMat;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) GetComponent<MeshRenderer>().material = yMat;
    }
}
