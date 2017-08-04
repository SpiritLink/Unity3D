using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Unity2D : MonoBehaviour {

    public AudioClip GetCoin;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider2D;

	void Start () {
        // Variable Caching
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        audioSource.clip = GetCoin;

    }
	
	void Update () {
        if (GameManager.Instance.IsGameRunning == false) return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("Menu").SendMessage("AddScore", 5);
            audioSource.Play(); // 동전 획득 소리 재생
            spriteRenderer.enabled = false;
            circleCollider2D.enabled = false;

            // << : 여기서 동전을 생성하도록 변경한다 ?
            // << : 동전을 생성해 달라는 메시지를 전송한다.

            Destroy(this.gameObject, 0.7f); // 일정 시간 이후 오브젝트 제거
        }
    }
}
