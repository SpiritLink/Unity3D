using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDownForce : MonoBehaviour {

    [Range(1,50)]
    public float fForce = 1.0f;
 
	void Start () {
		
	}
	
	void Update () {
        AddForce();
	}

    void AddForce()
    {
        // 함수 안에서 AddForce를 실행
        gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.up * fForce);
    }
}
