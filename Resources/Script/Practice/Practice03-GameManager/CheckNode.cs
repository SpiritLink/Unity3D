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
        ID = GameObject.Find("Menu").GetComponent<RaceMenu>().GetID();
    }

    void Update () {
		
	}

    // Node 와 충돌하면 실행되는 함수입니다.
    void CheckPoint(int Value)
    {
        CheckPointDic[Value] = true;
        Debug.Log("CheckPointDic[" + Value.ToString() + "] = true");

        // 모든 노드를 거쳤다면
        if(CheckPointDic.Count == GameObject.Find("NodeManager").GetComponent<NodeManager_CarGame>().GetNodeCnt())
        {
            CheckPointDic.Clear();
            GameObject.Find("Menu").SendMessage("Round", ID);

            // 임시 게임 정지
            //GameManager.Instance.IsGameRunning = false;
        }
    }
}
