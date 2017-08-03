using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMirror : MonoBehaviour {

    private Camera camera;

	void Start () {
        camera = GetComponentInParent<Camera>();
	}
	
	void Update () {
		
	}

    private void OnPreCull()
    {
        camera.ResetProjectionMatrix();
        camera.projectionMatrix = camera.projectionMatrix *
            Matrix4x4.Scale(new Vector3(-1, 1, 1)); // 좌우 변경
    }

    private void OnPreRender()
    {
        GL.invertCulling = true;
    }

    private void OnPostRender()
    {
        GL.invertCulling = false;
    }
}
