using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Cannon : MonoBehaviour {

    Vector3 BasicPosition;
    float fRotation = 0.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void RotateCannon(float Value)
    {
        fRotation = Mathf.Clamp(fRotation + Value, -5.0f, 5.0f);
    }
}
