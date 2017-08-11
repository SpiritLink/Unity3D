using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

using LitJson;

[System.Serializable]
class Unity2DSaveInfo
{
    public string name;
    public int Score;
};

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
    public int TimeScore { get; set; }
    public int CoinScore { get; set; }

    public List<KeyValuePair<string, int>> Unity2DScore { get; set; }

    private void OnEnable()
    {
        Unity2DScore = new List<KeyValuePair<string, int>>();
    }

    private void Start()
    {
        LoadData();
    }

    public void InitGameManager()
    {
        if (Nickname == null)
            Nickname = "";
        IsGameRunning = true;
    }

    public int GetIndex()
    {
        return ObjectIndex++;
    }

    // 닉네임과 점수를 KeyValuePair 쌍으로 저장합니다.
    public void AddScore(int Score)
    {
        KeyValuePair<string, int> stData = new KeyValuePair<string, int>(Nickname, Score);
        Unity2DScore.Add(stData);
    }

    // 오름차순 정렬의 기준이 되는 함수
    static int ascending(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
    {
        // 클때 , 동등할때 , 적을때 총 3가지의 조건이 필요하다
        // 클때는 1, 동등할때는 0, 적을때는 -1을 리턴하면 된다.
        if (a.Value > b.Value)
            return 1;
        else if (a.Value == b.Value)
            return 0;
        else
            return -1;
    }

    // 내림차순 정렬의 기준이 되는 함수
    static int descending(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
    {
        // CompareTo를 이용해서 작성할 수도 있다.
        return -a.Value.CompareTo(b.Value);
    }

    // 점수를 정렬합니다.
    public void SortUnity2DScore()
    {
        Unity2DScore.Sort(descending);
        // 10개를 초과하는 요소가 있으면 제거합니다.
        if (Unity2DScore.Count > 10)
            Unity2DScore.RemoveRange(10, Unity2DScore.Count - 10);
    }

    // 리스트에 존재하는 스코어를 저장합니다.
    void SaveData()
    {
        JsonData infoJson = JsonMapper.ToJson(Unity2DScore);
        File.WriteAllText(Application.dataPath + "/Resources/JSONdata/PlayerInfoData.json",infoJson.ToString());
    }

    // 이진화된 데이터를 불러 List에 삽입합니다. (스코어)
    void LoadData()
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/Resources/JSONdata/PlayerInfoData.json");
        JsonData playerData = JsonMapper.ToObject(jsonString);

        // Key Value Pair Load
        var dict = JsonMapper.ToObject<List<KeyValuePair<string, int>>>(jsonString);
        foreach(KeyValuePair<string,int> kv in dict)
        {
            KeyValuePair<string, int> pData = new KeyValuePair<string, int>(kv.Key, kv.Value);
            Unity2DScore.Add(pData);
        }
    }

    // 종료되기 전 모든 정보를 저장합니다.
    private void OnDestroy()
    {
        SaveData();
    }
}
