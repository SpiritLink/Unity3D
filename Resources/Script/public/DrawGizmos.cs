using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour {

    public Vector3 AddPosition = new Vector3(0, 0, 0);

    public bool IsSphere = false;
    public Color Color_Sphere = Color.yellow;
    public float Sphere_Radius = 0.5f;

    public bool IsRight = false;
    public Color Color_Right = Color.red;
    public float Right_Length = 5.0f;

    public bool IsUp = false;
    public Color Color_Up = Color.green;
    public float Up_Length = 5.0f;

    public bool IsForward = false;
    public Color Color_Forward = Color.blue;
    public float Forward_Length = 5.0f;

	void Start () {
    }
	
	void Update () {
	}

    private void OnDrawGizmos()
    {
        if(IsSphere)
        {
            Gizmos.color = Color_Sphere;
            Gizmos.DrawSphere(transform.position + AddPosition, Sphere_Radius);
        }

        if(IsRight)
        {
            Gizmos.color = Color_Right;
            Gizmos.DrawRay(transform.position + AddPosition, transform.right * Right_Length);
        }

        if(IsUp)
        {
            Gizmos.color = Color_Up;
            Gizmos.DrawRay(transform.position + AddPosition, transform.up * Up_Length);
        }

        if(IsForward)
        {
            Gizmos.color = Color_Forward;
            Gizmos.DrawRay(transform.position + AddPosition, transform.forward * Forward_Length);
        }
    }
}
