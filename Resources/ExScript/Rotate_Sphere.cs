using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Sphere : MonoBehaviour {

    public float RotSpeed = 2.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Rotate_Sphere_Forward();
    }

    void Rotate_Sphere_Forward()
    {
        transform.rotation *= Quaternion.AngleAxis(RotSpeed, Vector3.right);    // x축 회전
    }
}
