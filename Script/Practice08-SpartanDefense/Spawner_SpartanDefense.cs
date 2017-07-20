using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_SpartanDefense : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    void AddObjCnt()
    {
        GameObject.Find("Menu").SendMessage("AddCnt");
    }
}
