using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanDefense_Camera : MonoBehaviour {

    public GameObject pTarget;
    public Vector3 CamPosition;
    Transform tr;

	void Start () {
        tr = GetComponent<Transform>();
	}
	
	void Update () {
        tr.position = pTarget.transform.position + CamPosition;
	}
}
