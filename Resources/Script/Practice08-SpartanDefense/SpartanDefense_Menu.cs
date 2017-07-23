using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpartanDefense_Menu : MonoBehaviour {

    private float fTime = 0.0f;
    public bool IsRunning = false;
    public int ObjCnt = 0;
    public int Life = 5;
    public int MaxLife = 5;

    Rect TimeArea = new Rect(0, 0, 100, 30);
    Rect ObjCntArea = new Rect(0, 30, 100, 30);
    Rect GameStart = new Rect(0, 60, 100, 30);
    Rect IsRunningArea = new Rect(0, 90, 100, 30);
    Rect MaxCntArea = new Rect(100, 0, 130, 30);
    Rect LifeArea = new Rect(0, 120, 100, 30);

	void Start () {
		
	}
	
	void Update () {
        Update_Time();
	}

    void InitData()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject pTarget in objs)
            Destroy(pTarget);
        fTime = 0.0f;
        IsRunning = true;
        ObjCnt = 0;
        Life = MaxLife;
        GameObject.Find("Spawner").SendMessage("SetIsRunning", true);
    }

    void Update_Time()
    {
        if (!IsRunning) return;

        fTime += Time.deltaTime;
    }

    void QuitGame()
    {
        IsRunning = false;
        GameObject.Find("Spawner").SendMessage("SetIsRunning", false);
    }

    void AddCnt()
    {
        ObjCnt++;
    }

    void SubCnt()
    {
        ObjCnt--;
    }

    void SubLife()
    {
        Life--;
        if (Life <= 0)
            QuitGame();
    }

    private void OnGUI()
    {
        GUI.TextField(TimeArea, fTime.ToString());
        GUI.TextField(ObjCntArea, ObjCnt.ToString());
        GUI.TextField(LifeArea, "Life : " + Life.ToString());
        if (!IsRunning)
            GUI.TextField(IsRunningArea, "게임 종료 !");

        if (GUI.Button(GameStart, "게임 시작"))
            InitData();
    }
}
