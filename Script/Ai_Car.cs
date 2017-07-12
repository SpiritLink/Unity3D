using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ai_Car : MonoBehaviour
{
    // Ray 연산을 위한 변수
    [Range(0, 50)]
    public float RayDistance = 10.0f;
    public float DistanceFL, DistanceFR, DistanceL, DistanceR;
    private RaycastHit rayHitFrontL, rayHitFrontR, rayHitL, rayHitR;
    private Ray rayFrontL, rayFrontR, rayL, rayR;

    // Move 연산을 위한 변수
    [Range(5, 20)]
    public float CarMaxSpeed = 5.0f;
    public float moveSpeed = 5.0f;
    private float fTime = 0.0f;

    // Node 연산을 위한 변수
    public int ID = -1;
    private Vector3 nextPoint = new Vector3(0, 0, 0);

    void Start()
    {
        rayFrontL = new Ray();
        rayFrontL.origin = this.transform.position;

        rayFrontR = new Ray();
        rayFrontR.origin = this.transform.position;

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
        DistanceFL = Mathf.Infinity;
        DistanceFR = Mathf.Infinity;

        Vector3 rayFrontPosition = this.transform.position;
        rayFrontPosition += (this.transform.forward * 1.0f);
        rayFrontL.origin = rayFrontPosition;
        rayFrontR.origin = rayFrontPosition;

        Vector3 rayLeftPosition = this.transform.position;
        rayL.origin = rayLeftPosition;
        rayL.direction = -this.transform.right;

        Vector3 rayRightPosition = this.transform.position;
        rayR.origin = rayRightPosition;
        rayR.direction = this.transform.right;

        // Calc Front Left Distance
        for(int iter = 1; iter < 6; ++iter)
        {
            Quaternion RotR = Quaternion.Euler(0.0f, 15.0f * iter, 0.0f);
            rayFrontR.direction = RotR * this.transform.forward;
            if(Physics.Raycast(rayFrontR.origin, rayFrontR.direction, out rayHitFrontR, RayDistance))
            {
                if (DistanceFR < rayHitFrontR.distance)
                    continue;
                DistanceFR = rayHitFrontR.distance;
            }
        }

        // Calc Front Right Distance
        for (int iter = 1; iter < 6; ++iter)
        {
            Quaternion RotL = Quaternion.Euler(0.0f, -15.0f * iter, 0.0f);
            rayFrontL.direction = RotL * this.transform.forward;
            if(Physics.Raycast(rayFrontL.origin, rayFrontL.direction, out rayHitFrontL, RayDistance))
            {
                if (DistanceFL < rayHitFrontL.distance)
                    continue;
                DistanceFL = rayHitFrontL.distance;
            }
        }

        // Calc Left Distance
        if (Physics.Raycast(rayL.origin, rayL.direction, out rayHitL, RayDistance))
            DistanceL = rayHitL.distance;

        // Clac Right Distance
        if (Physics.Raycast(rayR.origin, rayR.direction, out rayHitR, RayDistance))
            DistanceR = rayHitR.distance;

        if (Mathf.Abs(DistanceFL - DistanceFR) > 0.5f)
        {
            if (DistanceFL > DistanceFR)
                this.transform.rotation *= Quaternion.AngleAxis(-0.4f, Vector3.up);
            if (DistanceFR > DistanceFL)
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
        nextPoint = GameManager.Instance.GetNextNode(stData.Value);
    }

    private void OnCollisionEnter(Collision collision)
    {
        fTime = 0.0f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(rayFrontL.origin, rayFrontL.direction * RayDistance);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(rayFrontR.origin, rayFrontR.direction * RayDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(rayL.origin, rayL.direction * RayDistance);
        Gizmos.DrawRay(rayR.origin, rayR.direction * RayDistance);
    }

    Rect NextNodeArea = new Rect(300, 0, 200, 30);
    private void OnGUI()
    {
        GUI.TextField(NextNodeArea, "Ai 다음 노드 : " + nextPoint.ToString());
    }

}
