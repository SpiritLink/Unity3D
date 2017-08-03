using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMeshAgent_Menu : MonoBehaviour {

    public GameObject Enemy;
    private GameObject pNode;
    private float fTime;

    private AudioSource audioSource;
    public AudioClip GetClip;

    public int PlayerCnt
    {
        get;set;
    }
    public int EnemyCnt
    {
        get;set;
    }
    
    Rect NodeArea = new Rect(0, 150, 100, 30);
    Rect PlayerCntArea = new Rect(100, 0, 100, 30);
    Rect EnemyCntArea = new Rect(100, 30, 100, 30);

	void Start () {
        fTime = 0.0f;
        PlayerCnt = 0;
        EnemyCnt = 0;
        audioSource = GetComponent<AudioSource>();
    }
	
	void Update () {
        if(pNode == null)
        {
            GameObject.Find("Spawner").SendMessage("GenerateNode");
        }
	}

    void SetNode(GameObject pTarget)
    {
        pNode = pTarget;
        Enemy.SendMessage("SetTarget", pTarget);
    }

    private void OnGUI()
    {
        GUI.TextField(PlayerCntArea, "Player : " + PlayerCnt.ToString());
        GUI.TextField(EnemyCntArea, "Enemy : " + EnemyCnt.ToString());

        if (pNode != null)
            GUI.TextField(NodeArea, "노드 존재");
        else
            GUI.TextField(NodeArea, "노드 없음");
    }

    void PlaySound_Get()
    {
        audioSource.clip = GetClip;
        audioSource.Play();
    }
}
