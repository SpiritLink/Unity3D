using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl_Car : MonoBehaviour {

    Vector3 InitPosition;
    Quaternion InitRotation;
    public GameObject pTarget;
    private Transform pParentTransform;

    void Start () {
        InitPosition = this.transform.position;
        InitRotation = this.transform.rotation;
    }

    void Update () {
        RotateCamera();
        SetDir();
    }

    void RotateCamera()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            this.transform.RotateAround(pTarget.transform.position, pTarget.transform.up, -1.0f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            this.transform.RotateAround(pTarget.transform.position, pTarget.transform.up, 1.0f);
        }
    }

    void SetDir()
    {
        this.transform.LookAt(pTarget.transform.position);
    }
}
