using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default_NGUI : MonoBehaviour {

    public GameObject Popup;

    public UILabel labelTitle;
    public UILabel labelDescription;

    public GameObject itemObj = null;

    public int HP = 100;
    public UISprite barHP;
    static float timeHP = 0.0f;

    // 키보드 입력, 출력을 위한 변수
    public UIInput inputLabel;
    public UILabel labelOutput;

    void Start () {
        Init();
	}
	
	void Update () {
        timeHP += Time.deltaTime;
        if (timeHP > 0.01f)
        {
            HP--;
            if (HP < 0) HP = 100;

            barHP.fillAmount = HP * 0.01F;
            timeHP = 0.0f;
        }
            
	}

    void Init()
    {

        Popup.SetActive(false);

        labelTitle.text = string.Format("옵션");
        labelDescription.text = string.Format("{0}", "[00ffff]옵션설정[-]을 바꿔 주세요");

        // 기본 색상 지정
        labelDescription.color = Color.gray;

        //MakeItem();
    }

    void MakeItem()
    {
        if (itemObj == null)
            itemObj = Resources.Load<GameObject>("Prefab/Item");

        GameObject obj = Instantiate(itemObj, Vector3.zero, Quaternion.identity) as GameObject;

        Vector3 pos = Popup.gameObject.transform.localPosition;
        // 상속관계 설정
        obj.transform.parent = Popup.gameObject.transform;
        obj.transform.localPosition = new Vector3(pos.x, pos.y, -2.0f); // Z order 조정
        obj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        obj.SetActive(true);
    }

    public void OnClickOption()
    {
        if(Popup.activeSelf)
            Popup.SetActive(false);
        else
            Popup.SetActive(true);
        Debug.Log("On Click Option - Button Clicked");
    }

    public void OnClickConfirm()
    {
        Popup.SetActive(false);
        Debug.Log("Confirm");
    }

    public void OnClickCancel()
    {
        Popup.SetActive(false);
        Debug.Log("Cancel");
    }

    void OnSubmit()
    {
        labelOutput.text = inputLabel.text;
    }
}
