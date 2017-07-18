using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_TankTop : MonoBehaviour {

    [Range(100, 200)]
    public float fRotateSpeed = 100.0f;

    // 초기값 저장을 위한 변수
    Vector3 InitPosition;
    Quaternion InitRotation;

    // 캐논 회전을 위한 변수
    public GameObject pChild;


	void Start () {
        InitPosition = this.transform.position;
        InitRotation = this.transform.rotation;
	}
	
	void Update () {
    }

    void Move_Rotate_Top(float Value)
    {
            float rotate = fRotateSpeed * Time.deltaTime * Value;
            gameObject.transform.Rotate(Vector3.up * rotate);
            pChild.SendMessage("RotateLR", rotate);
    }
}
