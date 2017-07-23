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

    // GUI 수업시간에 배웠던 내용 
    private void OnGUI()
    {
        // 같은 기능
        //GUI.TextArea(new Rect(10, 5, 400, 30), CollisionObjName);
        //GUI.TextField(new Rect(10, 45, 400, 30), CollisionObjName);
        //GUILayout.Label(CollisionObjName);  // << : 지정을 따로 해줘야함

        //if (IsBoost)
        //{
        //    GUI.TextField(new Rect(10, 45, 300, 30), "부스트 활성화 " + CurrentMaxSpeed.ToString());
        //}
        //// 버튼이 눌렸을때 한번만 수행
        //if (GUI.Button(new Rect(500, 300, 100, 30), "부스트"))
        //{
        //    fStatusTime = 10.0f;
        //}

        //// 버튼이 눌렸을때 여러번 수행
        //if (GUI.RepeatButton(new Rect(300, 300, 50, 30), "<<"))
        //{
        //    float rotate = -1;
        //    rotate = rotate * speedRotate * Time.deltaTime;
        //    gameObject.transform.Rotate(Vector3.up * rotate);
        //    print("좌회전");
        //}
        //if (GUI.RepeatButton(new Rect(400, 300, 50, 30), ">>"))
        //{
        //    float rotate = +1;
        //    rotate = rotate * speedRotate * Time.deltaTime;
        //    gameObject.transform.Rotate(Vector3.up * rotate);
        //    print("우회전");
        //}
    }


}
