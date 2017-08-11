using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity2D_GameScore : MonoBehaviour {

    public UILabel CoinScore;
    public UILabel TimeScore;
    public UILabel ResultScore;

	void Start () {
        int Coin = GameManager.Instance.CoinScore;
        int Time = GameManager.Instance.TimeScore;
        int Result = Coin + Time;

        CoinScore.text = Coin.ToString();
        TimeScore.text = Time.ToString();
        ResultScore.text = Result.ToString();
	}
	
	void Update () {
		
	}
}
