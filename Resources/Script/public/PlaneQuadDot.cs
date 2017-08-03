using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneQuadDot : MonoBehaviour {

    public GameObject LeftUp;
    public GameObject RightUp;
    public GameObject RightDown;
    public GameObject LeftDown;

    Rect LUArea = new Rect(0, 0, 150, 30);
    Rect RUArea = new Rect(0, 30, 150, 30);
    Rect RDArea = new Rect(0, 60, 150, 30);
    Rect LDArea = new Rect(0, 90, 150, 30);

    void Start()
    {

    }

    void Update()
    {

    }

    public Vector3 CalcRndPos()
    {
        Vector3 result = new Vector3(0, 0, 0);
        float T1 = Random.Range(0.0f, 1.0f);
        float T2 = Random.Range(0.0f, 1.0f);

        Vector3 P0 = LeftDown.transform.position;                                  // 원점
        Vector3 V1 = LeftUp.transform.position      - LeftDown.transform.position; // 위를 향하는 벡터 
        Vector3 V2 = RightDown.transform.position   - LeftDown.transform.position; // 오른쪽을 향하는 벡터

        result = P0 + (T1 * V1) + (T2 * V2); // 원점에서 V1으로 T1만큼 이동 (위쪽), V2로 T2만큼 이동 (오른쪽)
        return result;
    }

    private void OnGUI()
    {
        //GUI.TextField(LUArea, "LR : " + LeftUp.transform.position.ToString());
        //GUI.TextField(RUArea, "RU : " + RightUp.transform.position.ToString());
        //GUI.TextField(RDArea, "RD : " + RightDown.transform.position.ToString());
        //GUI.TextField(LDArea, "LD : " + LeftDown.transform.position.ToString());
    }

}
