using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Unity2D : MonoBehaviour {

    private int Score;
    private float fTime;
    public GameObject pPlayer;
    public GameObject pUI;

    void Start()
    {
        Score = 0;
        fTime = 0.0f;
    }

    void Update()
    {
        Update_PlayerHP();
        fTime += Time.deltaTime;
    }

    void AddScore(int Value)
    {
        Score += Value;
        pUI.GetComponent<UI_Unity2D>().ShowScore(Score);
    }

    void Update_PlayerHP()
    {
        if (pPlayer == null || pUI == null) return;
        int HP;
        HP = pPlayer.GetComponent<Player_Unity2D>().nHp;
        pUI.GetComponent<UI_Unity2D>().ShowHPbar(HP);

        // 플레이어가 죽을 경우 
        if (HP <= 0)
        {
            int TimeScore = (int)fTime * 10;
            int CoinScore = Score;
            GameManager.Instance.TimeScore = TimeScore;
            GameManager.Instance.CoinScore = CoinScore;

            int ResultScore = TimeScore + CoinScore;
            GameManager.Instance.AddScore(ResultScore); // << : 닉네임과 점수를 묶어서 저장합니다.
            GameManager.Instance.SortUnity2DScore();
            SceneManager.LoadScene("13Unity2D_Result");
            // 이때 약간 딜레이를 줘야하나 ?
        }
    }


}
