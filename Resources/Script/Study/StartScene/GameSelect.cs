using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelect : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void Button1()
    {
        SceneManager.LoadScene("Practice03-GameManager");
    }

    public void Button2()
    {
        SceneManager.LoadScene("Practice04-BallRoll");
    }

    public void Button3()
    {
        SceneManager.LoadScene("Practice07-Spartan");
    }

    public void Button4()
    {
        SceneManager.LoadScene("Practice08-SpartanDefense");
    }

    public void Button5()
    {
        SceneManager.LoadScene("13Unity2D");
    }
}
