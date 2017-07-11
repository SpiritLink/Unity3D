using System.Collections;
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
        other.SendMessage("CheckPoint", 
            new KeyValuePair<string, int>(Name, Value));
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        //ActiveCheckPoint(other.gameObject);

        switch (other.gameObject.tag)
        {
            case "Car":
                print("체크 포인트");
                if (meleeAction == MeleeAction.CheckPoint)
                {
                    ActiveCheckPoint(other.gameObject);
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
