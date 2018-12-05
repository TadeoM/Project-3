﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour {

    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("q"))
            transform.Rotate(0, speed * Time.deltaTime, 0);
        if (Input.GetKey("e"))
            transform.Rotate(0, -speed * Time.deltaTime, 0);
        if (Input.GetKey("w"))
            transform.Translate(Vector3.forward * speed / 2.0f * Time.deltaTime);
        if (Input.GetKey("a"))
            transform.Translate(-Vector3.right * speed / 2.0f * Time.deltaTime);
        if (Input.GetKey("s"))
            transform.Translate(-Vector3.forward * speed / 2.0f * Time.deltaTime);
        if (Input.GetKey("d"))
            transform.Translate(Vector3.right * speed / 2.0f * Time.deltaTime);
    }
}