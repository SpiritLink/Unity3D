using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using LitJson;
// : https://lbv.github.io/litjson/

public class PlayerInfo
{
    public int ID;
    public string Name;
    public double Gold;

    public PlayerInfo(int id, string name, double gold)
    {
        ID = id;
        Name = name;
        Gold = gold;
    }
}

public class JSONTest : MonoBehaviour {

    public List<PlayerInfo> playerInfoList = new List<PlayerInfo>();

	void Start () {
        SavePlayerInfo();
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
        {
            LoadPlayerInfo();
        }
	}

    public void SavePlayerInfo()
    {
        Debug.Log("SavePlayerInfo");

        // >> : 
        playerInfoList.Add(new PlayerInfo(1, "이름1", 1000));
        playerInfoList.Add(new PlayerInfo(2, "이름2", 1001));
        playerInfoList.Add(new PlayerInfo(3, "이름3", 1002));
        playerInfoList.Add(new PlayerInfo(4, "이름4", 1003));
        playerInfoList.Add(new PlayerInfo(5, "이름5", 1004));
        playerInfoList.Add(new PlayerInfo(6, "이름6", 1005));
        playerInfoList.Add(new PlayerInfo(7, "이름7", 1006));
        // << :

        JsonData infoJson = JsonMapper.ToJson(playerInfoList);

        File.WriteAllText(Application.dataPath + "/Resources/JSONdata/PlayerInfoData.json",infoJson.ToString());
    }

    public void LoadPlayerInfo()
    {
        Debug.Log("LoadPlayerInfo");
        string jsonString = File.ReadAllText(Application.dataPath + "/Resources/JSONdata/PlayerInfoData.json");
        Debug.Log(jsonString);

        JsonData playerData = JsonMapper.ToObject(jsonString);
        ParsingJsonPlayerInfo(playerData);
    }

    private void ParsingJsonPlayerInfo(JsonData pData)
    {
        
        for (int i = 0; i < pData.Count; i++)
        {
            Debug.Log(pData[i]["ID"].ToString() + pData[i]["Name"] + pData[i]["Gold"]);

            // Add Data
            PlayerInfo plData = new PlayerInfo((int)pData[i]["ID"],(string)pData[i]["Name"],(double)pData[i]["Gold"]);
            playerInfoList.Add(plData);
        }
    }
}
