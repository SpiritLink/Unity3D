using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Unity2D : MonoBehaviour {

    public float speed = 0.25f;
    private Renderer renderer;

    void Start () {
        speed = 0.25f;
        renderer = GetComponent<Renderer>();
    }
	
	void Update () {
        //if (GameManager.Instance.IsGameRunning == false) return;
        Vector2 offset = new Vector2(Time.time * speed, 0);
        renderer.material.mainTextureOffset = offset;
	}
}
