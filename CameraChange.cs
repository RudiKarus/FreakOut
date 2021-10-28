using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public float camSpeed = 4;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        
        if (Input.GetKey(KeyCode.X)) transform.Translate(Vector3.forward * camSpeed, Space.Self);
        else if (Input.GetKey(KeyCode.Y)) transform.Translate(Vector3.back * camSpeed, Space.Self);
        /*
        else if (Input.GetKey(KeyCode.O)) transform.Rotate(0, 1*camSpeed/4, 0, Space.World);
        else if (Input.GetKey(KeyCode.P)) transform.Rotate(0, -1*camSpeed/4, 0, Space.World);
        */
        if (Input.GetKey(KeyCode.UpArrow))  transform.RotateAround(new Vector3(-1.5f, 0, 1.5f), new Vector3(1, 0, 0), 0.5f);
        if (Input.GetKey(KeyCode.DownArrow)) transform.RotateAround(new Vector3(-1.5f, 0, 1.5f), new Vector3(1, 0, 0), -0.5f);
        if (Input.GetKey(KeyCode.LeftArrow)) transform.RotateAround(new Vector3(-1.5f, 0, 1.5f), new Vector3(0, 1, 0), 0.5f);
        if (Input.GetKey(KeyCode.RightArrow)) transform.RotateAround(new Vector3(-1.5f, 0, 1.5f), new Vector3(0, 1, 0), -0.5f);
        
    }
}
