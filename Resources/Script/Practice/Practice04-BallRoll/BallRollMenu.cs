using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallRollMenu : MonoBehaviour {

    Rect StartGame = new Rect(0, 30, 100, 30);
    Rect QuitGame = new Rect(0, 60, 100, 30);

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnGUI()
    {
        if(!GameManager.Instance.IsGameRunning)
        {
            if (GUI.Button(StartGame, "게임 시작"))
            {
                GameManager.Instance.IsGameRunning = true;
                GameObject.Find("Sphere").SendMessage("Init");
                GameObject.Find("Floor").SendMessage("Init");
            }
            if (GUI.Button(QuitGame, "게임 종료"))
            {
                SceneManager.LoadScene("StartMenu");
            }
        }
    }
}
