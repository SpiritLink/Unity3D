using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject obstaclePrefab;
    public float interval = 1.5f;
    public bool IsRunning = false;

    public Vector3 MinRange;
    public Vector3 MaxRange;

	IEnumerator Start () {
		while(true)
        {
            // Prefab을 찍어내는 명령어
            float AddX = Random.Range(MinRange.x, MaxRange.x);
            float AddY = Random.Range(MinRange.y, MaxRange.y);
            float AddZ = Random.Range(MinRange.z, MaxRange.z);

            Vector3 newPos = new Vector3(transform.position.x + AddX, transform.position.y + AddY, transform.position.z + AddZ);
            if(IsRunning)
            {
                this.gameObject.SendMessage("AddObjCnt");
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
