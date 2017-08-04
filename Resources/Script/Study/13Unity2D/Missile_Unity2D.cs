using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Unity2D : MonoBehaviour {

    public GameObject pEffect;

    public float MoveSpeed = 0.0f;
    private int Direction = 0;

	void Start () {
        Destroy(this.gameObject, 5.0f);
	}
	
	void Update ()
    {
        if (GameManager.Instance.IsGameRunning == false) return;

        if (Direction == 1)
            this.transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);

        if(Direction == -1)
            this.transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
    }

    void SetLeft()
    {
        Direction = -1;
    }

    void SetRight()
    {
        Direction = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(pEffect,this.transform.position, this.transform.rotation);
            GameObject.Find("Spawner_Coin").SendMessage("GenerateCoin", this.transform.position);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
