using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject obstaclePrefab;
    public float interval = 1.5f;
    bool IsRunning = false;

	IEnumerator Start () {
		while(true)
        {
            // Prefab을 찍어내는 명령어
            float pos = Random.Range(-5.0f, 5.0f);
            Vector3 newPos = new Vector3(transform.position.x, transform.position.y + pos, transform.position.z);
            if(IsRunning)
            {
                Instantiate(obstaclePrefab, newPos, transform.rotation);
            }
            yield return new WaitForSeconds(interval); // << : 몇초뒤에 다시 돌아오시오
        }
	}
	
	void Update () {
		
	}

    void SetIsRunning(bool value)
    {
        IsRunning = value;
    }
}
