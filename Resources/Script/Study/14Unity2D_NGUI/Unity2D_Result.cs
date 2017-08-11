using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unity2D_Result : MonoBehaviour {

	void Start () {
	}
	
	void Update () {
	}

    public void Button_Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Button_Retry()
    {
        SceneManager.LoadScene("13Unity2D");
    }
}
