using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour {

    public UIInput input;
    public GameObject Popup_Nickname;
    public GameObject Popup_GameSelect;

    private void Awake()
    {
        GameManager.Instance.InitGameManager();
    }

    void Start () {
        InitPopup();
    }
	
	void Update () {
    }

    private void InitPopup()
    {
        if (GameManager.Instance.Nickname.Length < 1)
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

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
