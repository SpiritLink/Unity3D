using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject pTarget;
    public GameObject pParent;
    public string SetTag;
    public float delayTime;
    //private GameObject[] ParentsGameObject;
    //private Transform parentTr;

	void Start () {
        //ParentsGameObject = GetComponentsInParent<GameObject>();

        //foreach(GameObject parentGameObject in ParentsGameObject)
        //{
        //    if(parentGameObject.tag == "Player")
        //    {
        //        parentTr = parentGameObject.GetComponent<Transform>();
        //        break;
        //    }
        //}
	}
	
	void Update () {

    }

    void Generate()
    {
        GameObject Bullet = Instantiate(pTarget, transform.position + (pParent.transform.forward * 1.0f), pParent.transform.rotation);
        Bullet.tag = SetTag;
        Bullet.GetComponent<Rigidbody>().AddForce(pParent.transform.forward * 1000);
    }

}
