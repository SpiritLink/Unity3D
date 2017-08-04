using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Coin_Unity2D : MonoBehaviour {

    public GameObject pCoin;

	void Start () {
	}
	
	void Update () {
	}

    IEnumerator GenerateCoin(Vector3 Position)
    {
        yield return new WaitForSeconds(0.7f);
        if (GameManager.Instance.IsGameRunning != false)
            Instantiate(pCoin, Position, this.transform.rotation);
    }
}
