using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Unity2D : MonoBehaviour {

    public float moveSpeed = 10.0f;

	void Start () {
		
	}
	
	void Update () {

        if (GameManager.Instance.IsGameRunning == false) return;

        this.transform.Translate(Vector2.left * moveSpeed);

        if (this.transform.position.x < -910)
        {
            Vector2 nextPosition = this.transform.position;
            nextPosition.x = 990;
            this.transform.position = nextPosition;
        }
	}
}
