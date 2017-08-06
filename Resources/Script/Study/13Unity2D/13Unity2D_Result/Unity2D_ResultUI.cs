using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unity2D_ResultUI : MonoBehaviour {

    public Text Text_CoinScore;
    public Text Text_TimeScore;
    public Text Text_ResultScore;

	void Start () {
        Text_CoinScore.text = "Test Coin";
        Text_TimeScore.text = "Test Time";
        Text_ResultScore.text = "Test Result";
		
	}
	
	void Update () {
		
	}
}
