using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MapObject")
        {
            GameObject.Find("Menu").SendMessage("SubCnt");
            Destroy(collision.gameObject);
        }
    }
}
