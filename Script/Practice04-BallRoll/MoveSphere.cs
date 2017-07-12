using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour {

    Rect GravityTrueArea = new Rect(0, 30, 200, 30);
    Rect GravityFalseArea = new Rect(0, 60, 200, 30);

    void Start () {
        GetComponent<Rigidbody>().useGravity = false;
    }

    void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            GameManager.Instance.IsGameRunning = false;
            GameManager.Instance.IsGameQuit = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // 공이 빠져 나갔을때
        if(other.gameObject.tag == "MapObject")
        {
            GameManager.Instance.IsGameRunning = false;
            if(GameManager.Instance.IsGameQuit == false)
                GameManager.Instance.IsFailed = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
    }

    private void OnGUI()
    {
        if (GUI.Button(GravityTrueArea, "게임 시작"))
        {
            GameManager.Instance.IsGameRunning = true;
            GameManager.Instance.PlayTime = 0.0f;
            GetComponent<Rigidbody>().useGravity = true;
        }
        if(GUI.Button(GravityFalseArea, "Use Gravity False"))
        {
            GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
