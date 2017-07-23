using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelfAction { BuffDebuff, ChangeHP, ChangeArmor, None };
public enum SelfType { Armor, Potion, None };

public class ItemSelf : MonoBehaviour {

    public GameObject Player;
    public int Amount, Value, ArmorAmount;
    public float Weight;
    public string Name, Stat;
    public SelfAction selfAction = SelfAction.None;
    public SelfType selfType = SelfType.None;

	void Start () {
		
	}
	
	void Update () {
		
	}

    void BuffDebuffStat()
    {
        Player.SendMessage("BuffDebuffStat",
            new KeyValuePair<string, int>(Stat, Amount));
    }

    void ChangeHealth()
    {
        Player.SendMessage("ChangeHealth", Amount);
    }

    void ChangeArmorAmount()
    {
        Player.SendMessage("ChangeArmorAmount", ArmorAmount);
    }

    void Activate()
    {
        switch (selfAction)
        {
            case SelfAction.BuffDebuff:
                BuffDebuffStat();
                break;
            case SelfAction.ChangeHP:
                ChangeHealth();
                break;
            case SelfAction.ChangeArmor:
                ChangeArmorAmount();
                break;
        }

        if (selfType == SelfType.Potion)
            Destroy(gameObject);
    }
}
