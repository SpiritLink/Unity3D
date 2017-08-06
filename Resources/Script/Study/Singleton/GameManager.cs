using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

#region Singleton Initialize
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

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
#endregion

    // All Parts Data
    public bool IsGameRunning { get; set; }
    private int ObjectIndex = 0;

    // Player Data
    public string Nickname { get; set; }

    // Unity 2D Data
    public List<int> Unity2DScore
    { get; set; }

    private void OnEnable()
    {
        Unity2DScore = new List<int>();
    }

    public void InitGameManager()
    {
        Nickname = "";
        IsGameRunning = true;
    }

    public int GetIndex()
    {
        return ObjectIndex++;
    }
}
