using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spartan_Ai : MonoBehaviour {

	void Start () {
        gameObject.SendMessage("SetV", -1.0f);
    }

    void Update () {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerWeapon")
        {
            GameObject.Find("Menu").SendMessage("SubCnt");
            Destroy(this.gameObject);
            Debug.Log("PlayerWeapon");
        }

        if(other.gameObject.tag == "MapObject")
        {
            GameObject.Find("Menu").SendMessage("SubCnt");
            GameObject.Find("Menu").SendMessage("SubLife");
            Destroy(this.gameObject);
            Debug.Log("FinishLine");
        }
    }
}
