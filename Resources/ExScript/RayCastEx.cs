using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEx : MonoBehaviour {

    [Range(0, 50)]  // 어트리뷰트
    public float distance = 10.0f;
    private RaycastHit rayHit;
    private Ray ray;

	void Start () {
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
	}
	
	void Update () {
        //Ray_1_1();
        //Ray_1_2();
        Ray_1_3();
    }

    void Ray_1_1()  //맨앞에 충돌된것만 계산
    {
        if (Physics.Raycast(ray.origin, ray.direction, out rayHit, distance))
        {
            Debug.Log(rayHit.collider.gameObject.name);    // 유니티 콘솔창에 띄워줌
        }
    }

    private RaycastHit[] rayHits;
    void Ray_1_2()  //범위내의 모든충돌을 계산
    {
        rayHits = Physics.RaycastAll(ray, distance);

        for(int index = 0; index < rayHits.Length; index++)
        {
            Debug.Log(rayHits[index].collider.gameObject.name + "hit!!");
        }
    }

    void Ray_1_3()
    {
        ray.origin = this.transform.position;
        rayHits = Physics.RaycastAll(ray, distance);
        for (int index = 0; index < rayHits.Length; index++)
        {
            if(rayHits[index].collider.gameObject.tag == "Sphere")
                Debug.Log(rayHits[index].collider.gameObject.name + "hit!!");

            if (rayHits[index].collider.gameObject.layer == LayerMask.NameToLayer("Box"))
                Debug.Log(rayHits[index].collider.gameObject.name + "hit!! - Layer");

        }
    }

    private void OnDrawGizmos()
    {
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawRay(ray.origin, ray.direction * distance);
        //Gizmos.DrawSphere(ray.origin, 0.2f);
        //Gizmos.DrawWireSphere(ray.origin, 0.2f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(ray.origin, ray.direction * distance);
        Gizmos.DrawSphere(ray.origin, 0.2f);
    }
}
