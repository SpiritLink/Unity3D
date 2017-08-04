﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DefaultUI : MonoBehaviour {

    public Image imgHPBar;
    [Tooltip("Text Object")]
    public Text txtHP;
    public Text txtScore;
    public Text txtNickname;
    [Tooltip("Popup Object")]
    public GameObject Popup_Option;
    public GameObject Popup_Died;

    // BGM CheckBox
    [Tooltip("Toggle")]
    public GameObject Object_BGM;
    public GameObject Object_Player;
    public GameObject Object_Enemy;

    Toggle toggleBGM;
    Toggle togglePlayer;
    Toggle toggleEnemy;

    [Tooltip("Slider")]
    public GameObject Slider_BGM;
    public GameObject Slider_Player;
    public GameObject Slider_Enemy;

    Slider sliderBGM;
    Slider sliderPlayer;
    Slider sliderEnemy;

    // Radio Box
    public GameObject objToggleGroup;
    Toggle[] toggleRadio;

    private void Awake()
    {
        GameManager.Instance.IsGameRunning = true;
        Time.timeScale = 1.0f;
        ShowScore(0);
        Popup_Option.SetActive(false);
        Popup_Died.SetActive(false);

        toggleBGM = Object_BGM.GetComponent<Toggle>();
        togglePlayer = Object_Player.GetComponent<Toggle>();
        toggleEnemy = Object_Enemy.GetComponent<Toggle>();

        sliderBGM = Slider_BGM.GetComponent<Slider>();
        sliderPlayer = Slider_Player.GetComponent<Slider>();
        sliderEnemy = Slider_Enemy.GetComponent<Slider>();

        toggleRadio = objToggleGroup.GetComponentsInChildren<Toggle>();

        txtNickname.text = GameManager.Instance.Nickname;
    }
    void Start () {
        sliderBGM.value = SoundManager.Instance.MapObjectVolume;
        sliderPlayer.value = SoundManager.Instance.PlayerVolume;
        sliderEnemy.value = SoundManager.Instance.EnemyVolume;
    }
	
	void Update () {
		
	}

    public void ShowHPbar(int hp)
    {
        imgHPBar.fillAmount = (float)hp / (float)100;
        txtHP.text = "HP <color=#ff0000>" + hp.ToString() + "</color>";
    }

    public void ShowScore(int score)
    {
        txtScore.text = "Score <color=#0000ff>" + score.ToString() + "</color>";
    }

    public void ShowDiedMenu()
    {
        GameManager.Instance.IsGameRunning = false;
        Time.timeScale = 0.0f;
        Popup_Died.SetActive(true);
    }

    public void OnClickOptionPopup()
    {
        Debug.Log("OnClickOptionPopup");
        if (Popup_Option.activeSelf == true)
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

    public void Button_Cancel()
    {
        Debug.Log("Button_Cancel");
        Popup_Option.SetActive(false);
        GameManager.Instance.IsGameRunning = true;
        Time.timeScale = 1.0f;
    }

    public void Button_Confirm()
    {
        Debug.Log("Button_Confirm");
        Popup_Option.SetActive(false);
        GameManager.Instance.IsGameRunning = true;
        Time.timeScale = 1.0f;
    }

    public void Button_Retry()
    {
        Debug.Log("Button_Retry");
        SceneManager.LoadScene("13Unity2D");
    }

    public void Button_Menu()
    {
        Debug.Log("Button_Menu");
        SceneManager.LoadScene("13Unity2D_Menu");
    }

    public void OnToggle(string Type)
    {
        switch(Type)
        {
            case "BGM":
                if(toggleBGM.isOn)
                {
                    Debug.Log("BGM ON");
                }
                else
                {
                    Debug.Log("BGM OFF");
                    sliderBGM.value = 0.0f;
                    toggleBGM.isOn = false;
                }
                break;
            case "Player":
                if (togglePlayer.isOn)
                {
                    Debug.Log("Player ON");
                    // : to do something ...
                }
                else
                {
                    Debug.Log("Player OFF");
                    sliderPlayer.value = 0.0f;
                    togglePlayer.isOn = false;
                    // : to do something ...
                }
                break;
            case "Enemy":
                if(toggleEnemy.isOn)
                {
                    Debug.Log("Enemy ON");
                }
                else
                {
                    Debug.Log("Enemy OFF");
                    sliderEnemy.value = 0.0f;
                    toggleEnemy.isOn = false;
                }
                break;
        }
    }



    public void OnToggleRadio()
    {
        if(toggleRadio[0].isOn)
        {
            Debug.Log("Radio 0 - Checked");
        }
        else if(toggleRadio[1].isOn)
        {
            Debug.Log("Radio 1 - Checked");
        }
        else if(toggleRadio[2].isOn)
        {
            Debug.Log("Radio 2 - Checked");
        }
    }

    public void MoveSlider(string Type)
    {
        switch(Type)
        {
            case "BGM":
                if (!toggleBGM.isOn)
                    toggleBGM.isOn = true;
                SoundManager.Instance.MapObjectVolume = sliderBGM.value;
                break;
            case "Player":
                if (!togglePlayer.isOn)
                    togglePlayer.isOn = true;
                SoundManager.Instance.PlayerVolume = sliderPlayer.value;
                break;
            case "Enemy":
                if (!toggleEnemy.isOn)
                    toggleEnemy.isOn = true;
                SoundManager.Instance.EnemyVolume = sliderEnemy.value;
                break;
        }
    }
    
}
