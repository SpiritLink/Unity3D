using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float fTime = 0.0f;
    [Range(5.0f, 100.0f)]
    public float fMaxTime = 5.0f;
	void Start () {
		
	}
	
	void Update () {

        fTime += Time.deltaTime;
        if (fTime > fMaxTime)
            Destroy(this.gameObject);
	}
}
