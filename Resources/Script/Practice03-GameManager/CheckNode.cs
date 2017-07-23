using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNode : MonoBehaviour {

    public int ID = -1;
    Dictionary<int, bool> CheckPointDic = new Dictionary<int, bool>();
	// Use this for initialization
	void Start () {
        ID = GameManager.Instance.GetID();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CheckPoint(int Value)
    {
        CheckPointDic[Value] = true;
        Debug.Log("CheckPointDic[" + Value.ToString() + "] = true");

        if (CheckPointDic.Count == GameManager.Instance.NodeDic.Count)
        {
            CheckPointDic.Clear();
            Debug.Log("DicClear");
            CheckPointDic[1] = true;
            GameObject.Find("Menu").SendMessage("LapTime", ID);

            // 임시 게임 정지
            GameManager.Instance.IsGameRunning = false;
        }
    }
}
