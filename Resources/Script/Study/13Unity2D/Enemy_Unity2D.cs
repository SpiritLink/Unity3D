using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Unity2D : MonoBehaviour {

    private Rigidbody2D rigidBody;

    public float maxSpeed = 500.0f;
    public float LimitTime = 10.0f;
    private float fTime = 0.0f;
    private bool Flip = false;

    public float fMinAngle = 0.0f;
    public float fMaxAngle = 0.0f;
    public float fAngleInterval = 0.0f;
    private float fAngle = 180.0f;
    private bool IsSwitch = false;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        if (GameManager.Instance.IsGameRunning == false) return;
        Move_Enemy();
        DestroyObject();
        Update_Angle();
    }

    void Move_Enemy()
    {
        float fRad = Mathf.Deg2Rad * fAngle;
        Vector2 Move = new Vector2(Mathf.Cos(fRad), Mathf.Sin(fRad));
        Move = Move * maxSpeed * Time.deltaTime;

        Vector2 Origin = rigidBody.transform.position;
        //Vector2 NextPosition = new Vector2(Origin.x + AddVector, Origin.y);
        rigidBody.MovePosition(Origin + Move);
    }

    void DestroyObject()
    {
        fTime += Time.deltaTime;
        if (fTime > LimitTime)
            Destroy(this.gameObject);
    }

    void Update_Angle()
    {
        if (fAngle > fMaxAngle)
            IsSwitch = false;
        else if (fAngle < fMinAngle)
            IsSwitch = true;

        if (IsSwitch)
            fAngle += Time.deltaTime * fAngleInterval;
        else
            fAngle -= Time.deltaTime * fAngleInterval;
    }
}
