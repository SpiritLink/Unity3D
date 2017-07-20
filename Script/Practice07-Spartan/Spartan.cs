using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan : MonoBehaviour {

    Animation spartanKing;

    public AnimationClip PrevAnim;
    public GameObject pWeapon;
    private string Anim1Name;
    private string Anim2Name;

    // Player Control
    CharacterController pcControl;
    Vector3 MoveDir = new Vector3();

    // Keyboard Input
    private float h = 0.0f;
    private float v = 0.0f;
    private Transform tr;
    public float runSpeed = 10.0f;
    public float rotSpeed = 10.0f;
    private float startTime;
    public float journeyTime = 1.0f;

    // Status for Animation
    bool IsIdle = true;

    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        pcControl = gameObject.GetComponent<CharacterController>();
        spartanKing.wrapMode = WrapMode.Loop;
        IsIdle = true;
        startTime = Time.time;

        tr = this.gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        //AnimationPlay_1();
        //AnimationPlay_3();

        Update_Anim();
        CharacterMove();
    }

    void Update_Anim()
    {
        if (MoveDir.magnitude < 0.5f && IsIdle)   // 크기
        {
            spartanKing.CrossFade("idle", 0.3f);
        }
        else if (MoveDir.magnitude >= 0.5f && IsIdle)
        {
            spartanKing.CrossFade("run", 0.3f);
        }
    }

    void Attack()
    {
        IsIdle = false;
        pWeapon.gameObject.SetActive(true);
        spartanKing.wrapMode = WrapMode.Once;
        spartanKing.CrossFade("attack", 0.3f);
        StartCoroutine(SetFalseWithTime(pWeapon, spartanKing.GetClip("attack").length));
    }

    void CharacterMove()
    {
        MoveDir = (Vector3.forward * v) + (Vector3.right * h);

        if (!IsIdle) return;

        // Move (Slerp)
        //tr.position = Vector3.Slerp(tr.position, tr.position + MoveDir * runSpeed, 0.01f);//(Time.time - startTime) / journeyTime);
        //pcControl.SimpleMove(MoveDir.normalized);

        // Move (SimpleMove)
        pcControl.SimpleMove(MoveDir.normalized * Time.deltaTime * runSpeed);

        // Rotate
        tr.LookAt(tr.position + MoveDir);
    }

    void SetH(float value)
    {
        h = value;
    }

    void SetV(float value)
    {
        v = value;
    }

    IEnumerator SetFalseWithTime(GameObject Target, float fTime)
    {
        yield return new WaitForSeconds(fTime);
        Target.SetActive(false);
        IsIdle = true;
    }

    // 컨트롤러 콜라이더 히트
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }
}
