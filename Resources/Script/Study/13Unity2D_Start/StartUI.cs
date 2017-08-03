using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour {

    GameObject obj;
    public InputField inputText;


	void Start () {
		
	}
	
	void Update () {
		
	}

    public void onTextChanged()
    {
        Debug.Log(inputText.text);
        // : 입력된 내용 .. 텍스트 출력에 반영
    }

    public void onTextEditEnd()
    {
        Debug.Log(inputText.text);
        // : 글자수 확인.. 2글자 이상 8글자 이하
    }
}
