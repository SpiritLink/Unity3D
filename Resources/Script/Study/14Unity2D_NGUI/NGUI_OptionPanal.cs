using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NGUI_OptionPanal : MonoBehaviour {

    public UIToggle toggle_BGM;
    public UIToggle toggle_Player;
    public UIToggle toggle_Enemy;

    public UISlider slider_BGM;
    public UISlider slider_Player;
    public UISlider slider_Enemy;

    public UIToggle[] toggleBGMs;

    public AudioSource audioSource;

    public AudioClip[] BGMClips;

	void Start () {
        Init();
    }
	
	void Update () {
	}

    void Init()
    {
        toggle_BGM.value = true;
        toggle_Player.value = true;
        toggle_Enemy.value = true;

        slider_BGM.value = SoundManager.Instance.MapObjectVolume;
        slider_Player.value = SoundManager.Instance.PlayerVolume;
        slider_Enemy.value = SoundManager.Instance.EnemyVolume;
    }

    public void sliderMove_BGM()
    {
        SoundManager.Instance.ChangeVolume("MapObject", slider_BGM.value);
        if (slider_BGM.value == 0)
            toggle_BGM.value = false;
        else
            toggle_BGM.value = true;
    }

    public void sliderMove_Player()
    {
        SoundManager.Instance.ChangeVolume("Player", slider_Player.value);
        if (slider_Player.value == 0)
            toggle_Player.value = false;
        else
            toggle_Player.value = true;
    }

    public void sliderMove_Enemy()
    {
        SoundManager.Instance.ChangeVolume("Enemy", slider_Enemy.value);
        if (slider_Enemy.value == 0)
            toggle_Enemy.value = false;
        else
            toggle_Enemy.value = true;
    }

    public void toggleCheck_BGM()
    {
        if (toggle_BGM.value) return;

        slider_BGM.value = 0.0f;
        SoundManager.Instance.ChangeVolume("MapObject", 0.0f);
    }

    public void toggleCheck_Player()
    {
        if (toggle_Player.value) return;

        slider_Player.value = 0.0f;
        SoundManager.Instance.ChangeVolume("Player", 0.0f);
    }

    public void toggleCheck_Enemy()
    {
        if (toggle_Enemy.value) return;

        slider_Enemy.value = 0.0f;
        SoundManager.Instance.ChangeVolume("Enemy", 0.0f);
    }

    public void ChangeBGM()
    {
        for(int i = 0; i < toggleBGMs.Length; ++i)
        {
            if (!toggleBGMs[i].value) continue;

            audioSource.clip = BGMClips[i];
            audioSource.Play();
            break;
        }
    }

    public void Button_Menu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
