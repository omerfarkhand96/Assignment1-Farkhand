using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public float speed = 2.0f;

    private Vector3 pedPos;
    private Vector3 currPos;
    private Quaternion pedRot;
    private Quaternion currRot;
    Vector3 pedMove;
    private float timer = 100f;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        pedPos = transform.position;
        currPos = pedPos;
        pedRot = transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        currRot = pedRot;
        

        pedMove = transform.TransformDirection(0, 0, 1);
        anim.SetBool("Walk", true);
        if (currPos.x < 0f)
        {
            pedPos += pedMove * speed * Time.deltaTime;
            transform.position = pedPos;
        }
        else if (currPos.x > 0f)
        {
            pedPos -= pedMove * speed * Time.deltaTime;
            transform.position = pedPos;
        }

        Debug.Log(timer);
        if (timer <= 0)
        {
            {
                StartCoroutine(Countdown());
                Rotate();
                timer = 100;
            }
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
            pedRot.y = 180;
            transform.rotation = pedRot;
        }

        if (currRot.y <= 180 && currRot.y >= 175)
        {
            pedRot.y = 0;
            transform.rotation = pedRot;
        }

        if (currRot.y <= -90 && currRot.y >= -95)
        {
            pedRot.y = 90;
            transform.rotation = pedRot;
        }

        if (currRot.y >= 90 && currRot.y <= 95)
        {
            pedRot.y = -90;
            transform.rotation = pedRot;
        }
    }
}
