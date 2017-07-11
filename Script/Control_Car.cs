using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Car : MonoBehaviour {

    [Range(10, 50)]
    public float MaxSpeed = 10.0f;
    float speedMove = 10.0f;
    [Range(100, 200)]
    public float speedRotate = 100.0f;

    private float fTime = 0.0f;
    string CollisionObjName = "";

    public int ID = -1;
    public int NodeNumber = -1;

	// Use this for initialization
	void Start () {
        GameManager.Instance.PlayTime = 0.0f;
        ID = GameManager.Instance.GetID();
    }

    // Update is called once per frame
    void Update () {
        Move_Speed();
        Move_Rotate();
        Update_Speed();
    }

    void Move_Speed()
    {
        float move = Input.GetAxis("Vertical");
        move = move * speedMove * Time.deltaTime;

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
        fTime += Time.deltaTime;
        speedMove = 1.0f + (fTime * 5.0f);
        if (speedMove > MaxSpeed)
            speedMove = MaxSpeed;
    }

    void CheckPoint(KeyValuePair<string, int> stData)
    {
        print("Recv CheckPoint");
        Debug.Log("Check Point : " + stData.Value.ToString());
        NodeNumber = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        fTime = 0.0f;
        speedMove = 1.0f;
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
        // 같은 기능
        //GUI.TextArea(new Rect(10, 5, 400, 30), CollisionObjName);
        //GUI.TextField(new Rect(10, 45, 400, 30), CollisionObjName);
        //GUILayout.Label(CollisionObjName);  // << : 지정을 따로 해줘야함

        // 버튼이 눌렸을때 한번만 수행
        if(GUI.Button(new Rect(100, 200, 200, 30), "아이템"))
        {
            GUI.TextField(new Rect(100, 200, 170, 30), "버튼 클릭");
            print("버튼 클릭");
        }

        // 버튼이 눌렸을때 여러번 수행
        if (GUI.RepeatButton(new Rect(300, 300, 50, 30), "<<"))
        {
            float rotate = -1;
            rotate = rotate * speedRotate * Time.deltaTime;
            gameObject.transform.Rotate(Vector3.up * rotate);
            print("좌회전");
        }
        if (GUI.RepeatButton(new Rect(400, 300, 50, 30), ">>"))
        {
            float rotate = +1;
            rotate = rotate * speedRotate * Time.deltaTime;
            gameObject.transform.Rotate(Vector3.up * rotate);
            print("우회전");
        }
    }

}
