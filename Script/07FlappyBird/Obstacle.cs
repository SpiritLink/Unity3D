using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float speed = 5.0f;

	void Start () {
        Destroy(gameObject, 2.0f);  // 몇초뒤 오브젝트 삭제
	}
	
	void Update () {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
		
	}
}
