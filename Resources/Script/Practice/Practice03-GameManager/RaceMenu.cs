using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceMenu : MonoBehaviour {

    // 버튼 위치
    Rect StartMenu = new Rect(0, 100, 100, 30);
    Rect EndMenu = new Rect(0, 130, 100, 30);

    // 랩타임 저장
    Dictionary<int, float> PrevLapTimeDic = new Dictionary<int, float>();
    Dictionary<int, float> CurLapTImeDic = new Dictionary<int, float>();

    // 충돌차량 저장
    int ColCnt = 0;

    // 레이싱 게임 관련 변수

	void Start () {
		
	}
	
	void Update () {
		
	}

    void Init()
    {
        PrevLapTimeDic.Clear();
        CurLapTImeDic.Clear();
    }

    void AddColCnt()
    {
        ColCnt++;
    }

    void LapTime(int ID)
    {
        float LapTime, GameTime;
        if(!PrevLapTimeDic.ContainsKey(ID))
        {
        }
        else
        {
        }
    }

    Rect ColCntArea = new Rect(300, 0, 100, 30);
    private void OnGUI()
    {
        // 완주했으면 메뉴를 띄움
        if(!GameManager.Instance.IsGameRunning)
        {
            if (GUI.Button(StartMenu, "재시작"))
            {
                GameObject.Find("AiCar (1)").SendMessage("Init");
                GameObject.Find("AiCar (2)").SendMessage("Init");
                GameObject.Find("AiCar (3)").SendMessage("Init");
                //GameObject.Find("AiCar (4)").SendMessage("Init");
                //GameObject.Find("AiCar (5)").SendMessage("Init");

                GameObject.Find("MyCar").SendMessage("Init");
                Init();
            }
            if (GUI.Button(EndMenu, "메뉴 화면으로"))
            {
                SceneManager.LoadScene("StartMenu");
            }

            GUI.TextField(ColCntArea, "파괴차량 : " + ColCnt.ToString());
        }

        foreach (KeyValuePair<int, float> p in CurLapTImeDic)
        {
            GUI.TextField(new Rect(0, (p.Key + 3) * 30, 100, 30), p.Value.ToString());
        }
    }
}
