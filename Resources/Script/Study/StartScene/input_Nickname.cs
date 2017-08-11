using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_Nickname : MonoBehaviour {

    private UILabel uiLabel;

	void Start () {
        uiLabel = GetComponentInChildren<UILabel>();
	}
	
	void Update () {
		
	}

    public void OnSubmit()
    {
        GameManager.Instance.Nickname = uiLabel.text;
        SendMessageUpwards("InitPopup");
    }

    public void OnChange()
    {
    }
}
