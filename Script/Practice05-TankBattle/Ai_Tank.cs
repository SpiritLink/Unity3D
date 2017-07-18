using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Tank : MonoBehaviour {

    public GameObject pTarget;
    private float fFireTime;

    [Range(0, 1)]
    public float fMaxDot = 0.0f;
    public float fDot;
    public Vector3 fCross;


	void Start () {
        fFireTime = 0.0f;
        fDot = 0.0f;
        fCross = new Vector3(0, 0, 0);
    }
	
	void Update () {
		if(pTarget != null)
        {
            Update_Data();
            Update_Move();
            Update_Rotate_Body();
            Update_Rotate_Top();
            Update_Fire();
        }
	}

    void Update_Data()
    {
        Vector3 Dir = pTarget.transform.position - this.transform.position;
        Dir.Normalize();
        fDot = Vector3.Dot(this.transform.forward, Dir);

        fCross = Vector3.Cross(this.transform.forward, Dir);
    }

    void Update_Move()
    {

    }

    void Update_Rotate_Body()
    {
        // 내적이 기준보다 크다면 앞에 대상이 있으므로 몸체를 회전할 필요가 없어진다.
        if (fDot > fMaxDot) return;
        if (fDot > 0.99) return;    // 떨림현상 제거
        
        // 우측 뒤에 있는 상황일때
        if(fCross.y < 0)
        {
            this.gameObject.SendMessage("Move_Rotate_Body", -1);
        }
        else if(fCross.y > 0)
        {
            this.gameObject.SendMessage("Move_Rotate_Body", 1);
        }
        // 좌측 뒤에 있는 상황일때
    }

    void Update_Rotate_Top()
    {
        if (fDot < fMaxDot) return;
    }

    void Update_Fire()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, fCross * 5.0f);

        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(this.transform.position, this.transform.forward * 5.0f);

        Gizmos.color = Color.yellow;

        //float fDegree = 90.0f * (1 - fMaxDot); 
        float fDegree = Mathf.Acos(fMaxDot) * Mathf.Rad2Deg;
        Vector3 DirL = Quaternion.AngleAxis(-fDegree, this.transform.up) * this.transform.forward;
        Gizmos.DrawRay(this.transform.position, DirL * 10.0f);

        Vector3 DirR = Quaternion.AngleAxis(fDegree, this.transform.up) * this.transform.forward;
        Gizmos.DrawRay(this.transform.position, DirR * 10.0f);
    }
}
