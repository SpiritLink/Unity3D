using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO; // << : 바이너리로 저장하기 위해 추가됨
using System.Runtime.Serialization.Formatters.Binary;
using System;

[System.Serializable]
public class SaveInfomation
{
    public string name;
    public float posX;
    public float posY;
    public float posZ;
};

public class SaveLoad : MonoBehaviour {


	void Start () {
	}
	
	void Update () {

        if(Input.GetKeyDown(KeyCode.R))
        {
            // string 삽입
            string setID = "PlayerID";
            PlayerPrefs.SetString("ID", setID);
            Debug.Log("Saved: " + setID);
        }

        if(Input.GetKeyDown(KeyCode.T))
        {
            // string 출력
            if (!PlayerPrefs.HasKey("ID"))
            {
                Debug.Log("해당 ID 없음");
                return;
            }
            string getID = PlayerPrefs.GetString("ID");
            Debug.Log("Loaded: " + getID);
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Int, Float 삽입
            PlayerPrefs.SetInt("INT", 33);
            PlayerPrefs.SetFloat("FLOAT", 44.4f);

            int getInt = PlayerPrefs.GetInt("INT");
            float getFloat = PlayerPrefs.GetFloat("FLOAT");

            Debug.Log("Int: " + getInt.ToString());
            Debug.Log("Float: " + getFloat.ToString());
        }

        if(Input.GetKeyDown(KeyCode.U))
        {
            // 디폴트 데이터 삽입
            int getScore2 = PlayerPrefs.GetInt("Score2", 100);              // 저장된 데이터가 없다면 100으로 기본값이 저장된다.
            float getPosition2 = PlayerPrefs.GetFloat("Position2", 0.0f);   // 저장된 데이터가 없다면 0.0f로 기본값이 저장된다.
            string getID2 = PlayerPrefs.GetString("ID2", "NONE");           // 저장된 데이터가 없다면 NONE로 기본값이 저장된다.

            Debug.Log(getScore2.ToString());
            Debug.Log(getPosition2.ToString());
            Debug.Log(getID2.ToString());
        }

        if (Input.GetKeyDown(KeyCode.I))
        {

            SerializableSave();
        }


        //PlayerPrefs.Save(); // 모든 저장을 완전히 수행함
        //PlayerPrefs.DeleteAll(); // 모든 데이터를 완전히 삭제함
        //PlayerPrefs.DeleteKey("Score"); // 해당하는 값만 제거

    }

    void SerializableSave()
    {
        SaveInfomation setInfo = new SaveInfomation();

        Debug.Log("PosX: " + setInfo.posX.ToString() + "PosY: " + setInfo.posY.ToString() + "PosZ: " + setInfo.posZ.ToString());


        // Save
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memStream = new MemoryStream();    // << : 2진 데이터를 저장할 메모리 공간

        formatter.Serialize(memStream, setInfo);    // memStream에 setInfo 저장
        byte[] bytes = memStream.GetBuffer();
        String memStr = Convert.ToBase64String(bytes);
        PlayerPrefs.SetString("SaveInformation", memStr);
        Debug.Log(memStr);

        // Load
        string getInfos = PlayerPrefs.GetString("SaveInformation");
        Debug.Log(getInfos);

        byte[] getBytes = Convert.FromBase64String(getInfos);

        MemoryStream getMemStream = new MemoryStream(getBytes);

        BinaryFormatter formatter2 = new BinaryFormatter();

        SaveInfomation getInfomation = (SaveInfomation)formatter2.Deserialize(getMemStream);
        Debug.Log("PosX: " + getInfomation.posX.ToString() + "PosY: " + getInfomation.posY.ToString() + "PosZ: " + getInfomation.posZ.ToString());
    }
}
