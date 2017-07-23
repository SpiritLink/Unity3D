using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Renderer))]    // 이 스크립트 사용을 위해서는 Renderer가 필요하다.
public class MaterialTest : MonoBehaviour {

    private Renderer renderer;
    public Color oriColor;

    Material mat;
    // 코드를 이용한 머터리얼 조작

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        mat = renderer.material;
        oriColor = mat.color;
    }

    void Start () {
		
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            renderer.material.SetColor("_Color", Color.red);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            renderer.material.color = new Color(0, 1, 0, 1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            renderer.material.SetColor("_Color", new Color(0, 0, 1, 0.5f));
        }

        // : rendering mode
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            mat.SetFloat("_Mode", 0);//Opaque
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat.SetInt("_ZWrite", 1);

            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = -1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            mat.SetFloat("_Mode", 1);//Cutout
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
            mat.SetInt("_ZWrite", 1);

            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 2450;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            mat.SetFloat("_Mode", 2);//Fade
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);

            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            mat.SetFloat("_Mode", 3);//TransParent
            mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
            mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
            mat.SetInt("_ZWrite", 0);

            mat.DisableKeyword("_ALPHATEST_ON");
            mat.DisableKeyword("_ALPHABLEND_ON");
            mat.DisableKeyword("_ALPHAPREMULTIPLY_ON");
            mat.renderQueue = 3000;
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            //Application.LoadLevel("Practice03-GameManager");    // << : 구버전
            SceneManager.LoadScene("Practice03-GameManager");
        }
    }
}
