using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast_Car : MonoBehaviour {

    [Range(0, 50)]
    public float distance = 10.0f;
    private RaycastHit[] rayHitsL, rayHitsR;
    private Ray rayL;
    private Ray rayR;
    private float fDistanceL, fDistanceR;

	void Start () {
        rayL = new Ray();
        rayL.origin = this.transform.position;

        rayR = new Ray();
        rayR.origin = this.transform.position;
    }

    void Update () {
        RayUpdate();

    }

    void RayUpdate()
    {
        fDistanceL = Mathf.Infinity;
        fDistanceR = Mathf.Infinity;

        rayL.origin = this.transform.position;
        rayR.origin = this.transform.position;

        rayL.direction = this.transform.forward - this.transform.right;
        rayL.direction.Normalize();
        rayR.direction = this.transform.forward + this.transform.right;
        rayR.direction.Normalize();

        rayHitsL = Physics.RaycastAll(rayL, distance);
        rayHitsR = Physics.RaycastAll(rayR, distance);

        for(int index = 0; index < rayHitsL.Length; index++)
        {
            if (rayHitsL[index].collider.gameObject.tag != "MapObject")
                continue;
            if (fDistanceL < rayHitsL[index].distance)
                continue;
            fDistanceL = rayHitsL[index].distance;
        }

        for(int index = 0; index < rayHitsR.Length; index++)
        {
            if (rayHitsR[index].collider.gameObject.tag != "MapObject")
                continue;
            if (fDistanceR < rayHitsR[index].distance)
                continue;
            fDistanceR = rayHitsR[index].distance;
        }


        if (Mathf.Abs(fDistanceL - fDistanceR) > 0.5f)
        {
            if(fDistanceL > fDistanceR)
                this.transform.rotation *= Quaternion.AngleAxis(-0.4f, Vector3.up);
            if(fDistanceR > fDistanceL)
                this.transform.rotation *= Quaternion.AngleAxis(0.4f, Vector3.up);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(rayL.origin, rayL.direction * distance);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(rayR.origin, rayR.direction * distance);
    }
}
