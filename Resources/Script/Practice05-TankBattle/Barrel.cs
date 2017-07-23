using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌");
        Destroy(this.gameObject);
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌");
        Destroy(this.gameObject);
        Destroy(other.gameObject);
    }
}
