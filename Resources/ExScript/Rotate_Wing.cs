using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Wing : MonoBehaviour {
    public float RotSpeed = 2.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotate_Sphere_Up();
    }

    void Rotate_Sphere_Up()
    {
        transform.rotation *= Quaternion.AngleAxis(RotSpeed, Vector3.up);
    }
}
