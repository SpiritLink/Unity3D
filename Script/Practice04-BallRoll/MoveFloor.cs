using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour {

    [Range(20, 200)]
    public float speedRotate = 10.0f;

    Rect GameStartArea = new Rect(0, 30, 200, 30);
    void Start () {
        GameManager.Instance.PlayTime = 0.0f;
	}
	
	void Update () {
        Move_Rotate();
    }

    void Move_Rotate()
    {
        float ForwardRot = Input.GetAxis("Horizontal");
        ForwardRot = ForwardRot * speedRotate * Time.deltaTime;
        gameObject.transform.Rotate(Vector3.forward * ForwardRot);

        float RightRot = -Input.GetAxis("Vertical");
        RightRot = RightRot * speedRotate * Time.deltaTime;
        gameObject.transform.Rotate(Vector3.right * RightRot);
    }

    private void OnGUI()
    {
    }
}
