using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    Rect StartRace = new Rect(100, 100, 100, 30);
    Rect StartBall = new Rect(200, 100, 100, 30);

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnGUI()
    {
        if(GUI.Button(StartRace,"레이싱 시작"))
        {
            SceneManager.LoadScene("Practice03-GameManager");
        }

        if(GUI.Button(StartBall,"볼 시작"))
        {
            SceneManager.LoadScene("Practice04-BallRoll");
        }
    }
}
