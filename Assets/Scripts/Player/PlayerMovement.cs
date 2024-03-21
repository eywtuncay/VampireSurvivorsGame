using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public float movomentSpeed;

    public float minX, maxX, minY, maxY; // Haritanýn sýnýrlarý


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0,movomentSpeed*Time.deltaTime,0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -movomentSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-movomentSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(movomentSpeed * Time.deltaTime, 0, 0);
        }


        // Karakterin koordinatlarýný sýnýrla
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY);
        transform.position = currentPosition;

    }
}
