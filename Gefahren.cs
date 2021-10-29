using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gefahren : MonoBehaviour
{
    float startX;
    float aenderungX;

    void Start()
    {
        startX = transform.position.x;
        aenderungX = Random.Range(1.0f, 2.0f) * Time.deltaTime;
    }

    void Update()
    {
        float newX = transform.position.x + aenderungX;
        transform.position = new Vector3(newX, transform.position.y, 0);

        if(newX > startX + 2 || newX < startX - 2)
        {
            aenderungX = aenderungX * -1;
        }
    }
}
