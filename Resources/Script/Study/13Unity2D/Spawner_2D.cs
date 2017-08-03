using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_2D : MonoBehaviour {

    public GameObject pTarget;

    public float interval = 1.5f;
    public Vector2 MaxRange;
    public Vector2 MinRange;

	IEnumerator Start () {
		
        while(true)
        {
            float AddX = Random.Range(MinRange.x, MaxRange.x);
            float AddY = Random.Range(MinRange.y, MaxRange.y);

            Vector2 newPos = new Vector2(transform.position.x + AddX, transform.position.y + AddY);
            if (GameManager.Instance.IsGameRunning != false)
                Instantiate(pTarget, newPos, transform.rotation);

            yield return new WaitForSeconds(interval);
        }
	}
	
	void Update () {
		
	}
}
