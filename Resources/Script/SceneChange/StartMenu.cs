using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour {

    // 메뉴 진입이 처음인지 확인합니다.
    private bool IsFirst;

    public GameObject Popup_Nickname;
    public GameObject Popup_GameSelect;

    public InputField InputField_Nickname;

    private void Awake()
    {
        GameManager.Instance.InitGameManager();
    }

    void Start () {
        InitPopup();
        if (GameManager.Instance.Nickname.Length < 1)
        {
            IsFirst = true;
            Popup_Nickname.SetActive(true);
            Popup_GameSelect.SetActive(false);
        }
        else
        {
            IsFirst = false;
            Popup_Nickname.SetActive(false);
            Popup_GameSelect.SetActive(true);
        }
    }
	
	void Update () {
    }

    private void InitPopup()
    {
        if (GameManager.Instance.Nickname.Length < 1)
        {
            IsFirst = true;
            Popup_Nickname.SetActive(true);
            Popup_GameSelect.SetActive(false);
        }
        else
        {
            IsFirst = false;
            Popup_Nickname.SetActive(false);
            Popup_GameSelect.SetActive(true);
        }
    }

    private void UpdatePopup()
    {
        if(IsFirst)
        {
            Popup_Nickname.SetActive(true);
            Popup_GameSelect.SetActive(false);
        }
        else
        {
            Popup_Nickname.SetActive(false);
            Popup_GameSelect.SetActive(true);
        }
    }

    
    public void SetNickname()
    {
        GameManager.Instance.Nickname = InputField_Nickname.text;
        Debug.Log(GameManager.Instance.Nickname);
        IsFirst = false;
        UpdatePopup();
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
