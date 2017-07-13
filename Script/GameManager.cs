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

    public bool IsGameRunning = false;
    public bool IsGameQuit = false;
    public bool IsFailed = false;

    Rect TimeArea = new Rect(0, 0, 100, 30);
    Rect NodeNumArea = new Rect(100, 0, 100, 30);
    Rect QuitArea = new Rect(0, 90, 200, 30);
    Rect FailedArea = new Rect(0, 120, 200, 30);

    // 노드 관리를 위한 변수
    public Dictionary<int, GameObject> NodeDic = new Dictionary<int, GameObject>();
    public float PlayTime = 0.0f;
    int ID = 0;

    // 랩타임을 위한 변수
    public Dictionary<int, float> DicLapTime = new Dictionary<int, float>();

    //스타트보다 먼저 실행되는 함수 (한번 호출이후 다시 호출되지는 않음)
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	
	void Update () {
        if(IsGameRunning)
            PlayTime += Time.deltaTime;
	}
    
    public int GetID()
    {
        return ID++;
    }

    public Vector3 GetNextNode(int ID)
    {
        if(!NodeDic.ContainsKey(ID + 1))
            return NodeDic[1].gameObject.transform.position;
        return NodeDic[ID + 1].gameObject.transform.position;
    }

    private void OnGUI()
    {
        GUI.TextField(TimeArea, PlayTime.ToString());
        if (IsGameQuit)
            GUI.TextField(QuitArea, "게임 클리어 !");
        if (IsFailed)
            GUI.TextField(FailedArea, "게임 실패 !");
        GUI.TextField(NodeNumArea, "NodeCnt : " + NodeDic.Count.ToString());
    }
}
