using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_Menu : MonoBehaviour {

    private float fTime = 0.0f;
    public bool IsRunning = false;
    public int MaxObjCnt = 5;
    private int ObjCnt = 0;
    private int ObjResult = 0;

    Rect TimeArea = new Rect(0, 0, 100, 30);
    Rect ObjCntArea = new Rect(0, 30, 100, 30);
    Rect GameStart = new Rect(0, 60, 100, 30);
    Rect IsRunningArea = new Rect(0, 90, 100, 30);
    
	void Start () {
        Update_Time();

    }
	
	void Update () {
        Update_Time();
    }

    void Update_Time()
    {
        if (!IsRunning)
            return;

        fTime += Time.deltaTime;
    }

    void QuitGame()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("MapObject");
        IsRunning = false;
        ObjCnt = 0;
        foreach (GameObject pTarget in objs)
            Destroy(pTarget);
        GameObject.Find("Spawner").SendMessage("SetIsRunning", false);
    }

    void AddCnt()
    {
        ObjCnt++;
        if (ObjCnt > MaxObjCnt)
        {
            QuitGame();
            return;
        }
        ObjResult = ObjCnt;
    }

    void SubCnt()
    {
        ObjCnt--;
    }
    private void OnGUI()
    {
        GUI.TextField(TimeArea, fTime.ToString());
        GUI.TextField(ObjCntArea, ObjResult.ToString());
        if(!IsRunning)
        {
            GUI.TextField(IsRunningArea, "게임 종료!");
        }
        if (GUI.Button(GameStart, "게임 시작"))
        {
            fTime = 0.0f;
            IsRunning = true;
            GameObject.Find("Spawner").SendMessage("SetIsRunning", true);
        }
    }
}
