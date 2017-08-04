using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Unity2D : MonoBehaviour {

    private int Score;
    public GameObject pPlayer;
    public GameObject pUI;

	void Start () {
        Score = 0;
    }
	
	void Update () {
        Update_PlayerHP();
    }

    void AddScore(int Value)
    {
        Score += Value;
        pUI.GetComponent<DefaultUI>().ShowScore(Score);
    }

    void Update_PlayerHP()
    {
        if (pPlayer == null || pUI == null) return;
        int HP;
        HP = pPlayer.GetComponent<Player_Unity2D>().nHp;
        pUI.GetComponent<DefaultUI>().ShowHPbar(HP);

        // 플레이어가 죽을 경우 
        if(HP <= 0)
        {
            pUI.GetComponent<DefaultUI>().ShowDiedMenu();
        }
    }
}
