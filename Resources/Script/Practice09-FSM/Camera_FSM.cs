using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FSM : MonoBehaviour {

    public GameObject pTarget;
    public Vector3 Position;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = pTarget.transform.position + Position;	
	}
}
