using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ai_Car : MonoBehaviour
{
    [Range(0, 50)]
    public float RayDistance = 10.0f;
    public float fDistanceL, fDistanceR;
    private RaycastHit rayHitL, rayHitR;
    private Ray rayL, rayR;

    [Range(5, 20)]
    public float CarMaxSpeed = 5.0f;
    public float moveSpeed = 5.0f;
    private float fTime = 0.0f;

    public int ID = -1;

    void Start()
    {
        rayL = new Ray();
        rayL.origin = this.transform.position;

        rayR = new Ray();
        rayR.origin = this.transform.position;

        ID = GameManager.Instance.GetID();
    }

    // Update is called once per frame
    void Update()
    {
        RayUpdate();
        MoveAiCar();
        UpdateMove();
    }

    void RayUpdate()
    {
        fDistanceL = Mathf.Infinity;
        fDistanceR = Mathf.Infinity;

        Vector3 rayOrigin = this.transform.position;
        rayOrigin += (this.transform.forward * 1.0f);
        rayL.origin = rayOrigin;
        rayR.origin = rayOrigin;

        for(int iter = 1; iter < 6; ++iter)
        {
            Quaternion RotR = Quaternion.Euler(0.0f, 15.0f * iter, 0.0f);
            rayR.direction = RotR * this.transform.forward;
            if(Physics.Raycast(rayR.origin, rayR.direction, out rayHitR, RayDistance))
            {
                if (fDistanceR < rayHitR.distance)
                    continue;
                fDistanceR = rayHitR.distance;
            }
        }

        for (int iter = 1; iter < 6; ++iter)
        {
            Quaternion RotL = Quaternion.Euler(0.0f, -15.0f * iter, 0.0f);
            rayL.direction = RotL * this.transform.forward;
            if(Physics.Raycast(rayL.origin, rayL.direction, out rayHitL, RayDistance))
            {
                if (fDistanceL < rayHitL.distance)
                    continue;
                fDistanceL = rayHitL.distance;
            }
        }

        if (Mathf.Abs(fDistanceL - fDistanceR) > 0.5f)
        {
            if (fDistanceL > fDistanceR)
                this.transform.rotation *= Quaternion.AngleAxis(-0.4f, Vector3.up);
            if (fDistanceR > fDistanceL)
                this.transform.rotation *= Quaternion.AngleAxis(0.4f, Vector3.up);
        }
    }

    void MoveAiCar()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime;
        Vector3 Direction = Vector3.forward;
        Direction.y = 0;
        transform.Translate(Direction * moveDelta);
    }

    void UpdateMove()
    {
        fTime += Time.deltaTime;
        moveSpeed = 1.0f + fTime * 2.0f;
        if (moveSpeed > CarMaxSpeed)
            moveSpeed = CarMaxSpeed;
    }

    void CheckPoint(KeyValuePair<string, int> stData)
    {
        print("Recv CheckPoint");
        Debug.Log("Check Point : " + stData.Value.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        fTime = 0.0f;
    }

    private void OnCollisionStay(Collision collision)
    {
    }

    private void OnCollisionExit(Collision collision)
    {
    }

    private void OnTriggerEnter(Collider col)
    {
    }

    private void OnTriggerStay(Collider other)
    {
    }

    private void OnTriggerExit(Collider other)
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(rayL.origin, rayL.direction * RayDistance);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(rayR.origin, rayR.direction * RayDistance);
    }
}
