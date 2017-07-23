using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float speed = 50.0f;
    public float RotSpeed = 2.0f;
	void Start () {
        //Rotate_2_1();
        //Rotate_2_2();
        //Rotate_2_3();
        //Rotate_2_4();
    }
	
	void Update () {
        Rotate_2_6();

    }

    void Rotate_2_1()
    {
        transform.eulerAngles = new Vector3(0.0f, 45.0f, 0.0f);
    }
    void Rotate_2_2()
    {
        Quaternion target = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        transform.rotation = target;
    }

    void Rotate_2_3()
    {
        transform.Rotate(Vector3.up * 60.0f);
    }

    void Rotate_2_4()
    {
        transform.rotation *= Quaternion.AngleAxis(45.0f, Vector3.forward); // Z축에 대한 회전
        transform.rotation *= Quaternion.AngleAxis(45.0f, Vector3.right);   // X축에 대한 회전
        transform.rotation *= Quaternion.AngleAxis(45.0f, Vector3.up);
    }

    void Rotate_2_5()
    {
        float rot = speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rot, Vector3.forward); // Z축에 대한 회전
        transform.rotation *= Quaternion.AngleAxis(rot, Vector3.right);   // X축에 대한 회전
        transform.rotation *= Quaternion.AngleAxis(rot, Vector3.up);

    }

    void Rotate_2_6()
    {
        RotSpeed = RotSpeed * 0.999f;
        transform.rotation *= Quaternion.AngleAxis(RotSpeed, Vector3.up); 
    }
}
