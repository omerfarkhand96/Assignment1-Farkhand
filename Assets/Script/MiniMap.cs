using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public GameObject mapUI;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 compassAngle = new Vector3();
        compassAngle.z = target.transform.eulerAngles.y;
        mapUI.transform.eulerAngles = compassAngle;
    }
}
