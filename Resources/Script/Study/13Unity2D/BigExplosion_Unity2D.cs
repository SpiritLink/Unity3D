using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigExplosion_Unity2D : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
