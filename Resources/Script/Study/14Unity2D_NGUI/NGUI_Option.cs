using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGUI_Option : MonoBehaviour {

    public GameObject Popup_Option;

	void Start () {
        Popup_Option.SetActive(false);
	}
	
	void Update () {
		
	}

    public void OnClickOption()
    {
        Debug.Log("OnClick");
        if (Popup_Option.activeSelf)
        {
            Popup_Option.SetActive(false);
            GameManager.Instance.IsGameRunning = true;
            Time.timeScale = 1.0f;
        }
        else
        {
            Popup_Option.SetActive(true);
            GameManager.Instance.IsGameRunning = false;
            Time.timeScale = 0.0f;
        }
    }
}
