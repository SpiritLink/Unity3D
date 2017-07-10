using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Car : MonoBehaviour {

    [Range(10, 50)]
    public float MaxSpeed = 10.0f;
    float speedMove = 10.0f;
    [Range(100, 200)]
    public float speedRotate = 100.0f;

    private float fTime = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move_Speed();
        Move_Rotate();
        Update_Speed();

    }

    void Move_Speed()
    {
        float move = Input.GetAxis("Vertical");
        move = move * speedMove * Time.deltaTime;

        Vector3 Direction = Vector3.forward;
        Direction.y = 0;
        gameObject.transform.Translate(Direction * move);
    }

    void Move_Rotate()
    {
        float rotate = Input.GetAxis("Horizontal");
        rotate = rotate * speedRotate * Time.deltaTime;

        gameObject.transform.Rotate(Vector3.up * rotate);
    }

    void Update_Speed()
    {
        fTime += Time.deltaTime;
        speedMove = 1.0f + (fTime * 3.0f);
        if (speedMove > MaxSpeed)
            speedMove = MaxSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        fTime = 0.0f;
        speedMove = 1.0f;
    }

    private void OnCollisionStay(Collision collision)
    {
    }

    private void OnCollisionExit(Collision collision)
    {
    }

    private void OnTriggerEnter(Collider col)
    {
    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
    }

}
