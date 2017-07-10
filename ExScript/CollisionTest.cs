using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

    float speedMove = 10.0f;
    float speedRotate = 100.0f;

	void Start () {
		
	}
	
	void Update () {
        Move_Rotate();
		
	}

    public void Move_Rotate()
    {
        float rotate = Input.GetAxis("Horizontal"); // 유니티 에디터에 내장되있음 (축에대한 키입력)
        float move = Input.GetAxis("Vertical");

        rotate = rotate * speedRotate * Time.deltaTime;
        move = move * speedMove * Time.deltaTime;

        gameObject.transform.Rotate(Vector3.up * rotate);
        gameObject.transform.Translate(Vector3.forward * move);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider 충돌 " + hitObject.name + " 와 충돌 시작");
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider 충돌 " + hitObject.name + " 와 충돌 중");
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider 충돌 " + hitObject.name + " 와 충돌 완료");
    }

    private void OnTriggerEnter(Collider col)
    {
        GameObject hitObject = col.gameObject;
        print("Collider 충돌 " + hitObject.name + " 와 Trigger 발생");
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Collider 충돌 " + hitObject.name + " 와 Trigger stay");
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Collider 충돌 " + hitObject.name + " 와 Trigger Exit");
    }

}
