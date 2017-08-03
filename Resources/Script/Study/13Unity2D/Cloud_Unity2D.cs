using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Unity2D : MonoBehaviour {

    private Transform ObjTransform;
    public float moveSpeed = 0.0f;
    public float MinSpeed;
    public float MaxSpeed;

	void Start () {
        ObjTransform = GetComponent<Transform>();
        Destroy(this.gameObject, 15.0f);
        moveSpeed = Random.Range(MinSpeed, MaxSpeed);
    }
	
	void Update () {
        if (GameManager.Instance.IsGameRunning == false) return;

        ObjTransform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}
