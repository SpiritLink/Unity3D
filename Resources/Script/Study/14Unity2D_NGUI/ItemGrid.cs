using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour {

    public GameObject itemObject = null;

	void Start () {
        LoadPrefabs();
        InitGrid();
	}
	
    // 필요한 프리팹을 로딩할때
    void LoadPrefabs()
    {
        if (itemObject == null)
            itemObject = Resources.Load<GameObject>("Prefab/Item");
    }

    // 그리드 초기화
    void InitGrid()
    {
        string[] itemNameString = new string[5]
        {
            "Item_condition", "Item_dubleBooster",
            "Item_grow_dev", "Item_grow_reset",
            "Item_player_extend"
        };

        for(int i = 0; i < itemNameString.Length; ++i)
        {
            List<KeyValuePair<string, int>> Data = new List<KeyValuePair<string, int>>();
            GameObject obj = Instantiate(itemObject, Vector3.zero, Quaternion.identity) as GameObject;
            obj.transform.parent = gameObject.transform;
            obj.transform.localPosition = gameObject.transform.localPosition + new Vector3(i * 190, 0, 0);
            obj.transform.localScale = new Vector3(1, 1, 1);
            // Local Scale은 아직 미적용함

            NGUI_Item in_item = obj.GetComponent<NGUI_Item>();
            in_item.itemSprite.spriteName = itemNameString[i];
            in_item.itemName.text = itemNameString[i];
        }
    }

	void Update ()
    {

    }
}
