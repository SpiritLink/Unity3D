using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_NavMeshAgent : MonoBehaviour {

    public GameObject pNode;
    public GameObject PlaneQuadDot;

	void Start () {
		
	}
	
	void Update () {
		
	}

    void GenerateNode()
    {
        Vector3 Position = PlaneQuadDot.GetComponent<PlaneQuadDot>().CalcRndPos();
        Position.y += 3.0f;
        GameObject Target = Instantiate(pNode, Position, transform.rotation);
        GameObject.Find("Menu").SendMessage("SetNode", Target);
    }
}
