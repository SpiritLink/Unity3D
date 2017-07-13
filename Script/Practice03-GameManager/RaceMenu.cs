using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceMenu : MonoBehaviour {

    Rect StartMenu = new Rect(0, 100, 100, 30);
    Rect EndMenu = new Rect(0, 130, 100, 30);
	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnGUI()
    {
        if(GUI.Button(StartMenu,"재시작"))
        {
            GameObject.Find("AiCar (1)").SendMessage("Init");
            GameObject.Find("AiCar (2)").SendMessage("Init");
            GameObject.Find("AiCar (3)").SendMessage("Init");
            GameObject.Find("AiCar (4)").SendMessage("Init");
            GameObject.Find("AiCar (5)").SendMessage("Init");

            GameObject.Find("MyCar").SendMessage("Init");

            GameManager.Instance.PlayTime = 0.0f;
            //SceneManager.LoadScene("Practice03-GameManager");
        }
        if(GUI.Button(EndMenu,"메뉴 화면으로"))
        {
            GameManager.Instance.NodeDic.Clear();
            SceneManager.LoadScene("StartMenu");
        }
    }
}
