using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanControl : MonoBehaviour {

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

	void Start () {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        pcControl = gameObject.GetComponent<CharacterController>();
        spartanKing.wrapMode = WrapMode.Loop;
        IsIdle = true;
        startTime = Time.time;

        tr = this.gameObject.GetComponent<Transform>();
    }
	
	void Update () {
        //AnimationPlay_1();
        //AnimationPlay_3();

        CharacterMove();
        CharacterControl();
    }

    private void AnimationPlay_1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            spartanKing.wrapMode = WrapMode.Loop;   // Mode
            spartanKing.CrossFade("walk", 0.3f);    // CrossFade
            //spartanKing.Play("walk");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("run", 0.3f);    // 
           // spartanKing.Play("run");
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
            spartanKing.Play("charge");

        if (Input.GetKeyDown(KeyCode.Alpha4))
            spartanKing.Play("idlebattle");

        if (Input.GetKeyDown(KeyCode.Alpha5))
            spartanKing.Play("resist");

        if (Input.GetKeyDown(KeyCode.Alpha6))
            spartanKing.Play("victory");

        if (Input.GetKeyDown(KeyCode.Alpha7))
            spartanKing.Play("salute");

        if (Input.GetKeyDown(KeyCode.Alpha8))
            spartanKing.CrossFade("die", 0.3f);

        if (Input.GetKeyDown(KeyCode.Alpha9))
            spartanKing.CrossFade("diehard",0.3f);

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("attack", 0.3f);
            //spartanKing.Play("attack");
        }
    }

    private void AnimationPlay_3()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (spartanKing.IsPlaying("resist") == true) return;

            StopCoroutine(Anim2Idle(Anim1Name, Anim2Name)); // << : Stop Coroutine
            Anim1Name = "resist";                           // << : Set Anim Name
            Anim2Name = "idle";
            StartCoroutine(Anim2Idle(Anim1Name, Anim2Name));// << : Start Coroutine
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (spartanKing.IsPlaying("attack") == true) return;
            StopCoroutine(Anim2Idle(Anim1Name, Anim2Name));
            Anim1Name = "attack";
            Anim2Name = "idle";
            StartCoroutine(Anim2Idle(Anim1Name, Anim2Name));
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (spartanKing.IsPlaying("victory") == true) return;
            StopCoroutine(Anim2Idle(Anim1Name, Anim2Name));
            Anim1Name = "victory";
            Anim2Name = "idle";
            StartCoroutine(Anim2Idle(Anim1Name, Anim2Name));
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (spartanKing.IsPlaying("salute") == true) return;
            StopCoroutine(Anim2Idle(Anim1Name, Anim2Name));
            Anim1Name = "salute";
            Anim2Name = "idle";
            StartCoroutine(Anim2Idle(Anim1Name, Anim2Name));
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (spartanKing.IsPlaying("die") == true) return;
            StopCoroutine(Anim2Idle(Anim1Name, Anim2Name));
            Anim1Name = "die";
            Anim2Name = "idle";
            StartCoroutine(Anim2Idle(Anim1Name, Anim2Name));
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (spartanKing.IsPlaying("diehard") == true) return;
            StopCoroutine(Anim2Idle(Anim1Name, Anim2Name));
            Anim1Name = "diehard";
            Anim2Name = "idle";
            StartCoroutine(Anim2Idle(Anim1Name, Anim2Name));
        }
    }

    IEnumerator AttackToIdle()
    {
        spartanKing.wrapMode = WrapMode.Once;
        spartanKing.CrossFade("attack", 0.3f);

        //float delayTime = 1.167f - 0.3f;                              // 애니메이션 시간 - CrossFade 시간 (하드코딩)
        float delayTime = spartanKing.GetClip("attack").length - 0.3f;  // 애니메이션 시간 - CrossFade 시간

        yield return new WaitForSeconds(delayTime);

        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.CrossFade("idle", 0.3f);
         //while(1)
         //yield return new WaitForSeconds(0.0f);도 가능하다
    }

    IEnumerator Anim2Idle(string anim1, string anim2)
    {
        spartanKing.wrapMode = WrapMode.Once;
        spartanKing.CrossFade(anim1, 0.3f);
        Debug.Log(anim1);

        float delayTime = spartanKing.GetClip(anim1).length - 0.3f;
        yield return new WaitForSeconds(delayTime);

        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.CrossFade(anim2, 0.3f);
        Debug.Log(anim2);
    }

    void CharacterControl()
    {
        if (MoveDir.magnitude < 0.5f && IsIdle)   // 크기
        {
            spartanKing.CrossFade("idle", 0.3f);
        }
        else if(MoveDir.magnitude >= 0.5f && IsIdle)
        {
            spartanKing.CrossFade("run", 0.3f);
            //tr.LookAt(tr.position + MoveDir);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            IsIdle = false;
            pWeapon.gameObject.SetActive(true);
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("attack", 0.3f);
            StartCoroutine(SetFalseWithTime(pWeapon, spartanKing.GetClip("attack").length));
        }
    }

    void CharacterMove()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
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
