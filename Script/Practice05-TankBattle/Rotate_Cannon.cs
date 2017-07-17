﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Cannon : MonoBehaviour {

    public GameObject pParent;
    public float fRotateSpeed = 100.0f;
    public float fAngle = 0.0f;
	void Start () {
		
	}
	
	void Update () {
        Move_RotateUpDown();
    }

    void Move_RotateUpDown()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (fAngle >30.0f) return;
            float rotate = fRotateSpeed * Time.deltaTime;
            gameObject.transform.RotateAround(pParent.transform.position, pParent.transform.right, -rotate);
            fAngle += rotate;
        }

        if (Input.GetKey(KeyCode.F))
        {
            if (fAngle < 0.0f) return;
            float rotate = fRotateSpeed * Time.deltaTime;
            gameObject.transform.RotateAround(pParent.transform.position, pParent.transform.right, rotate);
            fAngle -= rotate;
        }
    }
    void RotateLR(float fAngle)
    {
        gameObject.transform.RotateAround(pParent.transform.position, Vector3.up, fAngle);
    }
}
