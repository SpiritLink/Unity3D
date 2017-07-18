using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire_Missile : MonoBehaviour {
    public GameObject pTarget;
    [Range(0,10)]
    public float fFront = 0.0f;
    [Range(10, 1000)]
    public float fPower = 10;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FireMissile()
    {
        Vector3 TargetPos = this.transform.position + this.transform.up * fFront;
        GameObject target = Instantiate(pTarget, TargetPos, transform.rotation);

        Vector3 Power = this.transform.up * fPower;
        target.GetComponent<Rigidbody>().AddForce(Power);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, this.transform.up * 2.0f);
    }
}
