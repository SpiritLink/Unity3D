using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_NavMeshAgent : MonoBehaviour {

    public AudioClip GetClip;

	void Start () {
    }
	
	void Update () {
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MapObject")
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            GameObject.Find("Menu").SendMessage("PlaySound_Get");
            GameObject.Find("Menu").GetComponent<NavMeshAgent_Menu>().EnemyCnt++;
            Debug.Log("Enemy Get Point");
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Menu").SendMessage("PlaySound_Get");
            GameObject.Find("Menu").GetComponent<NavMeshAgent_Menu>().PlayerCnt++;
            Debug.Log("Player Get Point");
            Destroy(this.gameObject);
        }
    }
}
