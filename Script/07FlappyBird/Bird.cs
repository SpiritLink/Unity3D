using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    [Range(0,50)]
    public float jumpPower = 10.0f;

    Vector3 PrevPosition;
    Quaternion PrevRotation;
	void Start () {
        PrevPosition = this.transform.position;
        PrevRotation = this.transform.rotation;
        GameObject.Find("Spawner").SendMessage("SetIsRunning", true);
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Time.timeScale = 0.2f;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = 1.0f;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Time.timeScale = 2.0f;
        }

    }

    void Init()
    {
        this.transform.position = PrevPosition;
        this.transform.rotation = PrevRotation;
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().useGravity = false;
        GameObject.Find("Menu").SendMessage("SetIsGameRun",false);
        GameObject.Find("Spawner").SendMessage("SetIsRunning", false);
    }
}
