using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_TankTop : MonoBehaviour {

    [Range(20, 50)]
    public float fRotateSpeed = 20;

    // 초기값 저장을 위한 변수
    Vector3 InitPosition;
    Quaternion InitRotation;

    // 캐논 회전을 위한 변수
    public GameObject pChild;

    // 감지 영역을 위한 변수
    [Range(0, 1)]
    public float fMaxDot = 0.0f;
    public float fDot;
    public Vector3 fCross;



    void Start () {
        InitPosition = this.transform.position;
        InitRotation = this.transform.rotation;

        fRotateSpeed = 20.0f;
        fMaxDot = 0.95f;
        fDot = 0.0f;
        fCross = new Vector3(0, 0, 0);
    }

    void Update () {
    }

    void Move_Rotate_Top(float Value)
    {
            float rotate = fRotateSpeed * Time.deltaTime * Value;
            gameObject.transform.Rotate(Vector3.up * rotate);
            pChild.SendMessage("RotateLR", rotate);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float fDegree = Mathf.Acos(fMaxDot) * Mathf.Rad2Deg;
        Vector3 DirL = Quaternion.AngleAxis(-fDegree, this.transform.up) * this.transform.forward;
        Gizmos.DrawRay(this.transform.position, DirL * 10.0f);
        Vector3 DirR = Quaternion.AngleAxis(fDegree, this.transform.up) * this.transform.forward;
        Gizmos.DrawRay(this.transform.position, DirR * 10.0f);
    }

}
