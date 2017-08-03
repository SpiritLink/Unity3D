using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_FSM : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerWeapon")
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerWeapon")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
