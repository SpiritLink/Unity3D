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
    private int ID = -1;
    private Vector3 nextPoint = new Vector3(0, 0, 0);
    private Vector3 NextDirection;

    // 충돌 카운팅을 위한 변수
    public int ColCnt = 0;
    private float ColTime = 0.0f;

    // 렌더 설정 변경을 위한 변수
    private Renderer[] renderer;
    public Color oriColor;
    Material[] mat;

    // 초기값 저장을 위한 변수 (재시작 대비)
    Vector3 InitPosition;
    Quaternion InitRotation;

    // 임시 확인 변수

    private void Awake()
    {
        renderer = GetComponentsInChildren<Renderer>();
    }

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
        nextPoint = GameManager.Instance.GetNextNode(0);

        InitPosition = this.transform.position;
        InitRotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Update_Ray();
        MoveAiCar();
        Update_Move();
        Update_Direction();
        Update_Status();
    }

    void Init()
    {
        this.transform.position = InitPosition;
        this.transform.rotation = InitRotation;
        nextPoint = GameManager.Instance.GetNextNode(0);
    }

    void Update_Ray()
    {
        int LayerMask = ~(1 << 9);
        DistanceFL = Mathf.Infinity;
        DistanceFR = Mathf.Infinity;

        // Init Ray Position
        Vector3 rayFrontPosition = this.transform.position;
        rayFrontPosition += (this.transform.forward * 1.0f);
        rayFrontL.origin = rayFrontPosition;
        rayFrontR.origin = rayFrontPosition;

        rayL.origin = this.transform.position;
        rayL.direction = -this.transform.right;

        rayR.origin = this.transform.position;
        rayR.direction = this.transform.right;

        // Calc Front Left Distance
        for(int iter = 1; iter < 6; ++iter)
        {
            Quaternion RotR = Quaternion.Euler(0.0f, 15.0f * iter, 0.0f);
            rayFrontR.direction = RotR * this.transform.forward;
            if(Physics.Raycast(rayFrontR.origin, rayFrontR.direction, out rayHitFrontR, RayDistance, LayerMask))
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
            if(Physics.Raycast(rayFrontL.origin, rayFrontL.direction, out rayHitFrontL, RayDistance, LayerMask))
            {
                if (DistanceFL < rayHitFrontL.distance)
                    continue;
                DistanceFL = rayHitFrontL.distance;
            }
        }

        // Calc Left Distance
        if (Physics.Raycast(rayL.origin, rayL.direction, out rayHitL, RayDistance, LayerMask))
            DistanceL = rayHitL.distance;

        // Clac Right Distance
        if (Physics.Raycast(rayR.origin, rayR.direction, out rayHitR, RayDistance, LayerMask))
            DistanceR = rayHitR.distance;

        // Rotate Exception
        // 벽과 충돌한 상태일때
        if ((DistanceFL < 1.0f && DistanceFR < 1.0f) ||
            DistanceFL == Mathf.Infinity || DistanceFR == Mathf.Infinity)
        {
            // 외적을 구한뒤 좌로 회전할지 우로 회전할지 결정합니다. (충돌로 속도가 줄어든 상태)
            if (moveSpeed < 4.0f)
            {
                Vector3 V0 = this.transform.forward;
                Vector3 V1 = NextDirection;
                Vector3 V2 = Vector3.Cross(V0, V1);

                if (V2.y < 0)
                    this.transform.rotation *= Quaternion.AngleAxis(-3.0f, Vector3.up);
                else if (V2.y > 0)
                    this.transform.rotation *= Quaternion.AngleAxis(3.0f, Vector3.up);

                // this.transform.rotation = Quaternion.LookRotation(NextDirection, Vector3.up);
                // Quaternion.Lerp()를 이용해서 회전
            }
        }

        // 차량이 측면에 달라붙은 상황일때
        float Scalar = Vector3.Dot(this.transform.forward, NextDirection);
        if(Scalar > 0)
        {
            if (DistanceL < 1.5f)
                this.transform.rotation *= Quaternion.AngleAxis(0.4f, Vector3.up);
            if (DistanceR < 1.5f)
                this.transform.rotation *= Quaternion.AngleAxis(-0.4f, Vector3.up);
        }
        else if(Scalar < 0)
        {
            Vector3 V0 = this.transform.forward;
            Vector3 V1 = NextDirection;
            Vector3 V2 = Vector3.Cross(V0, V1);

            if (V2.y < 0)
                this.transform.rotation *= Quaternion.AngleAxis(-3.0f, Vector3.up);
            else if (V2.y > 0)
                this.transform.rotation *= Quaternion.AngleAxis(3.0f, Vector3.up);
        }

        // Rotate standard
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
        transform.Translate(Direction * moveDelta);
    }

    void Update_Move()
    {
        fTime += Time.deltaTime;
        moveSpeed = 1.0f + fTime * 2.0f;
        if (moveSpeed > CarMaxSpeed)
            moveSpeed = CarMaxSpeed;
    }

    void Update_Direction()
    {
        NextDirection = nextPoint - this.transform.position;
        NextDirection.Normalize();
        NextDirection.y = 0;
    }

    void Update_Status()
    {
        if (ColTime >= 0)
            ColTime -= Time.deltaTime;
    }
    void CheckPoint(KeyValuePair<string, int> stData)
    {
        nextPoint = GameManager.Instance.GetNextNode(stData.Value);
        // 자신의 아이디를 이용해 게임 매니저에 체크했다고 알림
    }

    private void OnCollisionEnter(Collision collision)
    {
        fTime = 1.0f;
        if(collision.gameObject.tag == "Player" && ColTime <= 0)
        {
            ColTime = 0.5f;
            ColCnt++;
            switch(ColCnt)
            {
                case 0:
                    break;
                case 1:
                    foreach (Renderer p in renderer)
                        p.material.SetColor("_Color", Color.green);
                    CarMaxSpeed = 10.0f;
                    break;
                case 2:
                    foreach (Renderer p in renderer)
                        p.material.SetColor("_Color", Color.yellow);
                    CarMaxSpeed = 5.0f;
                    break;
                case 3:
                    foreach (Renderer p in renderer)
                        p.material.SetColor("_Color", Color.red);
                    CarMaxSpeed = 1.0f;
                    break;
                default:
                    foreach (Renderer p in renderer)
                        p.material.SetColor("_Color", Color.red);
                    break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Draw Ray
        //Gizmos.color = Color.cyan;
        //Gizmos.DrawRay(rayFrontL.origin, rayFrontL.direction * RayDistance);
        //Gizmos.color = Color.cyan;
        //Gizmos.DrawRay(rayFrontR.origin, rayFrontR.direction * RayDistance);
        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(rayL.origin, rayL.direction * RayDistance);
        //Gizmos.DrawRay(rayR.origin, rayR.direction * RayDistance);

        // Draw Direction
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(this.transform.position, NextDirection * 5.0f);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position, this.transform.forward * 5.0f);
    }

    Rect NextNodeArea = new Rect(300, 0, 200, 30);
    private void OnGUI()
    {
        //GUI.TextField(NextNodeArea, "Ai 다음 노드 : " + nextPoint.ToString());
    }

}
