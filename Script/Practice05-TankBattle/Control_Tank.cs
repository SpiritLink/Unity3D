using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Tank : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            this.gameObject.SendMessage("Move_Speed", Input.GetAxis("Vertical"));

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            this.gameObject.SendMessage("Move_Rotate_Body", Input.GetAxis("Horizontal"));

        if(Input.GetKey(KeyCode.Q))
            this.gameObject.BroadcastMessage("Move_Rotate_Top", -1);

        if (Input.GetKey(KeyCode.E))
            this.gameObject.BroadcastMessage("Move_Rotate_Top", 1);

        if(Input.GetKey(KeyCode.R))
            this.gameObject.BroadcastMessage("Rotate_Cannon_Up");

        if(Input.GetKey(KeyCode.F))
            this.gameObject.BroadcastMessage("Rotate_Cannon_Down");

        if (Input.GetKeyDown(KeyCode.Space))
            this.gameObject.BroadcastMessage("FireMissile");
	}
}
