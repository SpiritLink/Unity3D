using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float moveSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        //gameObject.transform.position = new Vector3(0.0f, 5.0f, 0.0f);  // 절대적인 월드 좌표 (설정)
        //transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));           // 현재 위치의 상대적인 좌표 (이동)
	}
	
	// Update is called once per frame
	void Update () {
        //Move_1_3();
        //Move_1_4();
        MoveAiCar();
    }

    void Move_1_3() {
        float moveDelta = this.moveSpeed * Time.deltaTime;  // 시간차에 따른 보정 (T값)
        Vector3 pos = this.transform.position;
        pos.z += moveDelta;
        this.transform.position = pos;
    }

    void Move_1_4()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveDelta);
        // forward 는 바라보는 방향의 Z축으로 이동
    }

    void MoveAiCar()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime;
        Vector3 Direction = Vector3.forward;
        Direction.y = 0;
        transform.Translate(Direction * moveDelta);
    }

}
