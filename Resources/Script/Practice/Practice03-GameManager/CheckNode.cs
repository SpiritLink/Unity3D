using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckNode : MonoBehaviour {

    public int ID = -1;
    Dictionary<int, bool> CheckPointDic;

    private void Awake()
    {
        CheckPointDic = new Dictionary<int, bool>();
    }
    void Start () {
	}
	
	void Update () {
		
	}

    void CheckPoint(int Value)
    {
        CheckPointDic[Value] = true;
        Debug.Log("CheckPointDic[" + Value.ToString() + "] = true");

        if(CheckPointDic.Count == GameObject.Find("NodeManager").GetComponent<NodeManager_CarGame>().GetNodeCnt())
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
