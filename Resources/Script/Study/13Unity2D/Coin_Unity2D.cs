using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Unity2D : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (GameManager.Instance.IsGameRunning == false) return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("SceneManager").SendMessage("AddScore", 5);
            GameObject.Find("SceneManager").SendMessage("PlaySound_GetCoin");
            Destroy(this.gameObject);
        }
    }
}
