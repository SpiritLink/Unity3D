using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Car : MonoBehaviour {

    [Range(10, 50)]
    public float BaseMaxSpeed = 10.0f;
    public float CurrentMaxSpeed = 0.0f;
    float MoveSpeed = 10.0f;
    [Range(100, 200)]
    public float speedRotate = 100.0f;

    private float fColTime = 0.0f;
    string CollisionObjName = "";

    public int ID = -1;
    public float fStatusTime = 0.0f;
    public bool IsBoost = false;


	// Use this for initialization
	void Start () {
        GameManager.Instance.PlayTime = 0.0f;
        GameManager.Instance.IsGameRunning = true;
        ID = GameManager.Instance.GetID();

    }

    // Update is called once per frame
    void Update () {
        Move_Speed();
        Move_Rotate();
        Update_Speed();
        Update_Status();
    }

    void Move_Speed()
    {
        float move = Input.GetAxis("Vertical");
        move = move * MoveSpeed * Time.deltaTime;

        Vector3 Direction = Vector3.forward;
        Direction.y = 0;
        gameObject.transform.Translate(Direction * move);
    }

    void Move_Rotate()
    {
        float rotate = Input.GetAxis("Horizontal");
        rotate = rotate * speedRotate * Time.deltaTime;

        gameObject.transform.Rotate(Vector3.up * rotate);
    }

    void Update_Speed()
    {
        fColTime += Time.deltaTime;
        MoveSpeed = 1.0f + (fColTime * 5.0f);

        if (MoveSpeed > CurrentMaxSpeed)
            MoveSpeed = CurrentMaxSpeed;
    }

    void Update_Status()
    {
        if (fStatusTime > 0)
        {
            fStatusTime -= Time.deltaTime;
            IsBoost = true;
            CurrentMaxSpeed = BaseMaxSpeed + 10.0f;
        }
        else
        {
            IsBoost = false;
            CurrentMaxSpeed = BaseMaxSpeed;
        }
    }

    void CheckPoint(KeyValuePair<string, int> stData)
    {
        Debug.Log("Check Point : " + stData.Value.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        fColTime = 0.0f;
        MoveSpeed = 1.0f;
        if(collision.gameObject.tag != "MapObject")
            CollisionObjName = "CollisionEnter " + collision.gameObject.name;
        print(CollisionObjName);
    }

    private void OnCollisionStay(Collision collision)
    {
    }

    private void OnCollisionExit(Collision collision)
    {
    }

    private void OnTriggerEnter(Collider col)
    {
        //if (col.gameObject.tag != "MapObject")
        //    Debug.Log("OnTriggerEnter");
    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "MapObject")
            CollisionObjName = other.gameObject.name;
    }

    private void OnGUI()
    {
        if (IsBoost)
        {
            GUI.TextField(new Rect(500, 0, 70, 30), "Boost On!");
        }

        // 버튼이 눌렸을때 한번만 수행
        if (GUI.Button(new Rect(500, 300, 100, 30), "부스트"))
        {
            fStatusTime = 10.0f;
        }
    }

}
