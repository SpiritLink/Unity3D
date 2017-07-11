using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager sInstance;
    public static GameManager Instance
    {
        get
        {
            if(sInstance == null)
            {
                GameObject newGameObject = new GameObject("_GameManager");
                sInstance = newGameObject.AddComponent<GameManager>();
            }
            return sInstance;
        }
    }

    /* 플레이어 정보
     * 플레이 타임
     */

    public float PlayTime = 0.0f;
    int ID = 0;

    //스타트보다 먼저 실행되는 함수 (한번 호출이후 다시 호출되지는 않음)
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	
	void Update () {
        PlayTime += Time.deltaTime;
	}
    
    public int GetID()
    {
        return ID++;
    }

    private void OnGUI()
    {
        GUI.TextField(new Rect(350, 45, 70, 30), PlayTime.ToString());
    }
}
