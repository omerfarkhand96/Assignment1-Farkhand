using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 2.0f;

    private Vector3 carPos;
    private Vector3 currPos;
    private Quaternion carRot;
    private Quaternion currRot;
    Vector3 vehicleMove;
    private float timer = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
        carPos = transform.position;
        carRot = transform.rotation;
        currPos = carPos;
    }

    // Update is called once per frame
    void Update()
    {
        currRot = carRot;
        StartCoroutine(Countdown());
        vehicleMove = transform.TransformDirection(0, 0, 1);

        if (currPos.x < 0f)
        {
            carPos += vehicleMove * speed * Time.deltaTime;
            transform.position = carPos;
        }
        else if (currPos.x > 0f)
        {
            carPos -= vehicleMove * speed * Time.deltaTime;
            transform.position = carPos;
        }
        Debug.Log(timer);
        if (timer <= 0) {
            {
                Rotate();
                timer = 100;
            }
        }

    }

    // Triggers
    void OnTriggerExit(Collider other)
    {
 
        if(other.tag == "turn")
        {
            speed *= -1;
        }
    }

    IEnumerator Countdown()
    {
        timer -= 1;
        yield return new WaitForSeconds(2);
    }

    void Rotate()
    {
        if (currRot.y == 0)
        {
            carRot.y = 180;
            transform.rotation = carRot;
        }
        
        if (currRot.y <= 180 && currRot.y >= 175)
        {
            carRot.y = 0;
            transform.rotation = carRot;
        }
        
        if (currRot.y <= -90 && currRot.y >= -95)
        {
            carRot.y = 90;
            transform.rotation = carRot;
        }

        if (currRot.y >= 90 && currRot.y <= 95) 
        {
            carRot.y = -90;
            transform.rotation = carRot;
        }
    }
}
