using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Unity2D : MonoBehaviour {

	void Start () {
        Destroy(this.gameObject, 0.7f);
	}
	
	void Update () {
	}

}
