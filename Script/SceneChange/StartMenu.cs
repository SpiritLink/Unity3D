using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    Rect SelectMenu = new UnityEngine.Rect(200, 50, 200, 50);
    Rect StartRace = new Rect(200, 100, 100, 50);
    Rect StartBall = new Rect(300, 100, 100, 50);
    Rect StartFlappy = new Rect(400, 100, 100, 50);

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnGUI()
    {
        GUI.TextField(SelectMenu, "게임 선택");

        if(GUI.Button(StartRace,"레이싱 시작"))
        {
            SceneManager.LoadScene("Practice03-GameManager");
        }

        if(GUI.Button(StartBall,"볼 시작"))
        {
            SceneManager.LoadScene("Practice04-BallRoll");
        }

        if(GUI.Button(StartFlappy, "플래피 버드"))
        {
            SceneManager.LoadScene("07FlappyBird");
        }
    }
}
