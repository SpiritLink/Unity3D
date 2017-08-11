using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unity2D_Grid : MonoBehaviour {

    public GameObject itemObject = null;

	void Start () {
        LoadPrefabs();
        InitGrid();
	}
	
	void Update () {
		
	}

    void LoadPrefabs()
    {
        if(itemObject == null)
        {
            itemObject = Resources.Load<GameObject>("Prefab/Unity2D_Record");
        }
    }

    void InitGrid()
    {
        int nCnt = GameManager.Instance.Unity2DScore.Count;

        for(int i = 0; i < nCnt; ++i)
        {
            GameObject obj = Instantiate(itemObject, Vector3.zero, Quaternion.identity) as GameObject;
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition = gameObject.transform.localPosition + new Vector3(0, i * -50, 0);
            obj.transform.localScale = new Vector3(1, 1, 1);
            // Local Scale은 아직 미적용함

            NGUI_Record in_item = obj.GetComponent<NGUI_Record>();
            in_item.labelNickname.text = GameManager.Instance.Unity2DScore[i].Key;
            in_item.labelRecord.text = GameManager.Instance.Unity2DScore[i].Value.ToString();
        }

        // instantiate 한다.
    }
}
