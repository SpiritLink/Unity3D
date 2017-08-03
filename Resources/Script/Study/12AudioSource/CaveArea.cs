using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveArea : MonoBehaviour {

    public GameObject ReverbZone;

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ReverbZone.GetComponent<AudioReverbZone>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            ReverbZone.GetComponent<AudioReverbZone>().enabled = false;
        }
    }
}
