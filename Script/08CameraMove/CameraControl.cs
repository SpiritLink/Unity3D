using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    Camera mainCamera;
    Vector3 InitPosiion;
    Quaternion InitRotation;
    float InitFOV;
    
	void Start () {
        InitPosiion = transform.position;
        InitRotation = transform.rotation;
        mainCamera = GetComponent<Camera>();
        InitFOV = mainCamera.fieldOfView;

    }
	
	void Update () {
        MoveCamera();
        RotateCamera();
        ZoomCamera();
        if (Input.GetMouseButton(2))
            InitData();
	}

    void InitData()
    {
        transform.position = InitPosiion;
        transform.rotation = InitRotation;
        mainCamera.fieldOfView = InitFOV;
    }

    void MoveCamera()
    {
        if(Input.GetMouseButton(0))
        {
            this.transform.Translate(
                Input.GetAxisRaw("Mouse X") / 10.0f,
                Input.GetAxisRaw("Mouse Y") / 10.0f,
            0f);
        }
    }

    void RotateCamera()
    {
        // 카메라 회전은 주의해서 실행해야 한다. (원하지 않는 상황이 나올 수 있음)
        if(Input.GetMouseButton(1))
        {
            this.transform.Rotate(
                Input.GetAxisRaw("Mouse Y") * 10.0f,    // Y 값 변경
                Input.GetAxisRaw("Mouse X") * 10.0f,    // X 값 변경
                0.0f);
        }
    }

    void ZoomCamera()
    {
        mainCamera.fieldOfView +=
            (20 * -Input.GetAxis("Mouse ScrollWheel"));
        if (mainCamera.fieldOfView < 10)
            mainCamera.fieldOfView = 10.0f;
        if (mainCamera.fieldOfView > 150)
            mainCamera.fieldOfView = 150.0f;
    }

}
