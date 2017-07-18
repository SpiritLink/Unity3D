using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Cannon : MonoBehaviour {

    public GameObject pParent;
    public float fRotateSpeed = 100.0f;
    public float fAngle = 0.0f;

    [Range(0, 1)]
    public float fMaxDot = 0.0f;
    public float fDot;
    public Vector3 fCross;

	void Start () {
        fMaxDot = 0.95f;
        fDot = 0.0f;
        fCross = new Vector3(0, 0, 0);
	}
	
	void Update () {
    }

    void Update_Vector()
    {
    }

    void Rotate_Cannon_Up()
    {
        if (fAngle > 30.0f) return;
        float rotate = fRotateSpeed * Time.deltaTime;
        gameObject.transform.RotateAround(pParent.transform.position, pParent.transform.right, -rotate);
        fAngle += rotate;
    }

    void Rotate_Cannon_Down()
    {
        if (fAngle < 0.0f) return;
        float rotate = fRotateSpeed * Time.deltaTime;
        gameObject.transform.RotateAround(pParent.transform.position, pParent.transform.right, rotate);
        fAngle -= rotate;
    }
    void RotateLR(float fAngle)
    {
        gameObject.transform.RotateAround(pParent.transform.position, Vector3.up, fAngle);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        float fDegree = Mathf.Acos(fMaxDot) * Mathf.Rad2Deg;
        Vector3 DirL = Quaternion.AngleAxis(-fDegree, pParent.transform.up) * pParent.transform.forward;
        Gizmos.DrawRay(this.transform.position, DirL * 10.0f);
        Vector3 DirR = Quaternion.AngleAxis(fDegree, pParent.transform.up) * pParent.transform.forward;
        Gizmos.DrawRay(this.transform.position, DirR * 10.0f);
    }
}
