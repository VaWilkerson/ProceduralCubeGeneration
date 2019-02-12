using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{

    public float CameraRotateSpeed = 1.0f * 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(new Vector3(0.0f, 5.0f, 0.0f), new Vector3(1,0,0), CameraRotateSpeed);
    }
}
