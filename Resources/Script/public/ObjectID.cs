using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectID : MonoBehaviour
{

    private int ID = -1;

    private void Awake()
    {
        ID = GameManager.Instance.GetIndex();
    }

    void Start()
    {
        AudioSource audio;
        audio = GetComponent<AudioSource>();
        if (audio == null) return;

        SoundManager.Instance.AddAudio(ID, audio, this.gameObject.tag);
    }


    private void OnApplicationQuit()
    {
        Debug.Log("Delete Audio");
        SoundManager.Instance.DeleteAudio(ID, this.gameObject.tag);
    }
}