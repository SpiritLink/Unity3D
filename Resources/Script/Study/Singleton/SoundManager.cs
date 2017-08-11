using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    #region Singleton Initialize
    private static SoundManager sInstance;
    public static SoundManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new GameObject("_SoundManager");
                sInstance = newGameObject.AddComponent<SoundManager>();
            }
            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        // Memory allocation
        Player = new Dictionary<int, AudioSource>(); 
        Enemy = new Dictionary<int, AudioSource>(); 
        MapObject = new Dictionary<int, AudioSource>();
        Else = new Dictionary<int, AudioSource>();
    }
    #endregion

    // Volume
    public float PlayerVolume = 1.0f;
    public float EnemyVolume = 1.0f;
    public float MapObjectVolume = 1.0f;
    public float ElseVolume = 1.0f;

    // Objects Audio Source
    private Dictionary<int, AudioSource> Player;
    private Dictionary<int, AudioSource> Enemy;
    private Dictionary<int, AudioSource> MapObject;
    private Dictionary<int, AudioSource> Else;

    // Add Audio Source
    public void AddAudio(int ID, AudioSource audio, string Type)
    {
        switch(Type)
        {
            case "Player":
                audio.volume = PlayerVolume;
                Player.Add(ID, audio);
                Debug.Log("Add Player Audio");
                break;
            case "Enemy":
                audio.volume = EnemyVolume;
                Enemy.Add(ID, audio);
                Debug.Log("Add Enemy Audio");
                break;
            case "MapObject":
                audio.volume = MapObjectVolume;
                MapObject.Add(ID, audio);
                Debug.Log("Add MapObject Audio");
                break;
            default:
                audio.volume = ElseVolume;
                Else.Add(ID, audio);
                Debug.Log("Add Else Audio");
                break;
        }
    }

    // Mute All
    public void MuteAll()
    {
        foreach(KeyValuePair<int, AudioSource> audio in Player)
        {
            audio.Value.volume = 0.0f;
        }

        foreach (KeyValuePair<int, AudioSource> audio in Enemy)
        {
            audio.Value.volume = 0.0f;
        }

        foreach (KeyValuePair<int, AudioSource> audio in MapObject)
        {
            audio.Value.volume = 0.0f;
        }

        foreach (KeyValuePair<int, AudioSource> audio in Else)
        {
            audio.Value.volume = 0.0f;
        }
    }

    // Mute Partial
    public void Mute(string Type)
    {
        switch(Type)
        {
            case "Player":
                foreach (KeyValuePair<int, AudioSource> pTarget in Player)
                    pTarget.Value.volume = 0.0f;
                break;
            case "Enemy":
                foreach (KeyValuePair<int, AudioSource> pTarget in Enemy)
                    pTarget.Value.volume = 0.0f;
                break;
            case "MapObject":
                foreach (KeyValuePair<int, AudioSource> pTarget in MapObject)
                    pTarget.Value.volume = 0.0f;
                break;
            case "Else":
                foreach (KeyValuePair<int, AudioSource> pTarget in Else)
                    pTarget.Value.volume = 0.0f;
                break;
        }
    }

    // Active All
    public void ActiveAll()
    {
        foreach (KeyValuePair<int, AudioSource> audio in Player)
        {
            audio.Value.volume = 1.0f;
        }

        foreach (KeyValuePair<int, AudioSource> audio in Enemy)
        {
            audio.Value.volume = 1.0f;
        }

        foreach (KeyValuePair<int, AudioSource> audio in MapObject)
        {
            audio.Value.volume = 1.0f;
        }

        foreach (KeyValuePair<int, AudioSource> audio in Else)
        {
            audio.Value.volume = 1.0f;
        }
    }

    // Active Partial
    public void ChangeVolume(string Type, float Volume)
    {
        switch (Type)
        {
            case "Player":
                PlayerVolume = Volume;
                foreach (KeyValuePair<int, AudioSource> pTarget in Player)
                {
                    if (!pTarget.Value) continue;
                    pTarget.Value.volume = PlayerVolume;
                }
                break;
            case "Enemy":
                EnemyVolume = Volume;
                foreach (KeyValuePair<int, AudioSource> pTarget in Enemy)
                {
                    if (!pTarget.Value) continue;
                    pTarget.Value.volume = EnemyVolume;
                }
                break;
            case "MapObject":
                MapObjectVolume = Volume;
                foreach (KeyValuePair<int, AudioSource> pTarget in MapObject)
                {
                    if (!pTarget.Value) continue;
                    pTarget.Value.volume = MapObjectVolume;
                }
                break;
            case "Else":
                ElseVolume = Volume;
                foreach (KeyValuePair<int, AudioSource> pTarget in Else)
                {
                    if (!pTarget.Value) continue;
                    pTarget.Value.volume = ElseVolume;
                }
                break;
        }
    }

    // Delete Dictinary Data
    public void DeleteAudio(int ID, string tag)
    {
        switch(tag)
        {
            case "Player":
                Player.Remove(ID);
                break;
            case "Enemy":
                Enemy.Remove(ID);
                break;
            case "MapObject":
                MapObject.Remove(ID);
                break;
            default:
                Else.Remove(ID);
                break;
        }
    }

    private void OnDestroy()
    {
        Player.Clear();
        Enemy.Clear();
        MapObject.Clear();
        Else.Clear();
    }
}
