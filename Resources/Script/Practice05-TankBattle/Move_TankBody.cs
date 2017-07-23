using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_TankBody : MonoBehaviour {

    [Range(3, 10)]
    public float fMoveSpeed = 3.0f;
    [Range(10, 50)]
    public float fRotateSpeed = 10;

    // 초기값 저장을 위한 변수
    Vector3 InitPosition;
    Quaternion InitRotation;

	void Start () {
        InitPosition = this.transform.position;
        InitRotation = this.transform.rotation;
        fRotateSpeed = 10;

    }
	
	void Update () {
    }

    void Move_Speed(float Value)
    {
        float move = Value;
        move = move * fMoveSpeed * Time.deltaTime;

        Vector3 Direction = Vector3.forward;
        gameObject.transform.Translate(Direction * move);
    }

    void Move_Rotate_Body(float Value)
    {
        float rotate = Value;
        rotate = rotate * fRotateSpeed * Time.deltaTime;
        gameObject.transform.Rotate(Vector3.up * rotate);
    }
}
