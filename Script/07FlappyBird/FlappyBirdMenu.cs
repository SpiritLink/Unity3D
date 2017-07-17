using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBirdMenu : MonoBehaviour {

    private bool IsGameRun = true;
    public float PlayTime = 0.0f;

	void Start () {
		
	}
	
	void Update () {
        if(IsGameRun)
        {
            PlayTime += Time.deltaTime;
        }
	}

    void SetIsGameRun(bool Value)
    {
        IsGameRun = Value;
    }

    Rect StartGame = new Rect(0, 200, 100, 30);
    Rect EndGame = new Rect(0, 230, 100, 30);
    Rect TimeArea = new Rect(0, 0, 100, 30);
    Rect YouDie = new Rect(100, 100, 400, 100);
    private void OnGUI()
    {
        if (GUI.Button(StartGame, "게임 시작"))
        {
            GameObject.Find("Bird").SendMessage("Init");
            GameObject.Find("Spawner").SendMessage("SetIsRunning", true);
            PlayTime = 0.0f;
            SetIsGameRun(true);
        }
        if (GUI.Button(EndGame, "게임 종료"))
        {
            SceneManager.LoadScene("StartMenu");
        }

        if(!IsGameRun)
        {
            GUI.TextField(YouDie, "죽었습니다");
        }


        GUI.TextField(TimeArea, PlayTime.ToString());
    }
}
