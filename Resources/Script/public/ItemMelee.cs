﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MeleeAction { BuffDebuff, ChangeHP, ActivateEnv, CheckPoint, None };
public enum MeleeType { Weapon, Potion, Node, None };

public class ItemMelee : MonoBehaviour {

    public int Amount, Value;
    public float Weight;
    public string Name, Stat;
    public MeleeAction meleeAction = MeleeAction.None;
    public MeleeType meleeType = MeleeType.None;

    private void Awake()
    {
        if (meleeAction == MeleeAction.CheckPoint && meleeType == MeleeType.Node)
            GameObject.Find("NodeManager").GetComponent<NodeManager_CarGame>().AddNode(Value, this.gameObject);
    }

    void Start () {
	}
	
	void Update () {
		
	}

    void BuffDebuffStat(GameObject other)
    {
        other.SendMessage("BuffDebuffStat",
            new KeyValuePair<string, int>(Stat, Amount));
    }

    void ChangeHealth(GameObject other)
    {
        other.SendMessage("ChangeHealth", Amount);
    }

    void ActivateEnvironment(GameObject other)
    {
        other.SendMessage("Activate");
    }

    void ActiveCheckPoint(GameObject other)
    {
        other.SendMessage("ActiveCheckPoint", Value);
    }

    void CheckPoint(GameObject other)
    {
        other.SendMessage("CheckPoint",Value);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Car":
                if (meleeAction == MeleeAction.CheckPoint)
                {
                    ActiveCheckPoint(other.gameObject);
                    CheckPoint(other.gameObject);
                }
                break;
            case "Player":
                if (meleeAction == MeleeAction.CheckPoint)
                {
                    ActiveCheckPoint(other.gameObject);
                    CheckPoint(other.gameObject);
                }
                break;
            case "Enemy":
                    if (meleeType != MeleeType.Potion)
                    {
                        if (meleeAction == MeleeAction.ChangeHP)
                            ChangeHealth(other.gameObject);
                        if (meleeAction == MeleeAction.BuffDebuff)
                            BuffDebuffStat(other.gameObject);
                        if (meleeAction == MeleeAction.ActivateEnv)
                            ActivateEnvironment(other.gameObject);
                    }
                    break;
                case "Environment":
                    if (meleeType == MeleeType.Potion)
                    {
                        if (meleeAction == MeleeAction.ChangeHP)
                            ChangeHealth(other.gameObject);
                        if (meleeAction == MeleeAction.BuffDebuff)
                            BuffDebuffStat(other.gameObject);
                    }
                    break;
        }
        if (meleeType == MeleeType.Potion)
            Destroy(gameObject);
    }
}
