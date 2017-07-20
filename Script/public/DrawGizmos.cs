using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour {

    public float fSize = 0.5f;
	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, fSize);

        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(this.transform.position, this.transform.forward * 5.0f);
    }
}
