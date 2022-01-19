using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class TroopTypeScript : NetworkBehaviour {


    //Troop Stats

    public string troopType;

    public int pierceDamage;
    public int slashDamage;
    public int bluntDamage;

    public int pierceArmor;
    public int slashArmor;
    public int bluntArmor;

    public int morale;

    //Görev Yerleri
    public bool center;
    public bool rightFlank;
    public bool leftFlank;
    public bool rear;

    //List's order is important!
    //0.Weapon
    //1.Shield
    //2.Helm
    //3.Armor
    //4.Horse
    //5.Training
    public List<string> equipment;

    public enum Weapon
    {
        Spear,
        Sword,
        Axe,
        Mace,
        Bow,
        Crossbow,
        Pike,
        Lance
    }

    public enum Shield
    {
        LeatherShield,
        IronShield,
        SteelShield
    }

    public enum Helm
    {
        LeatherHelm,
        IronHelm,
        SteelHelm
    }

    public enum Armor
    {
        LeatherArmor,
        IronArmor,
        SteelArmor
    }

    public enum Horse
    {
        OnFoot,
        OnHorse
    }

    public enum Training
    {
        Militia,
        Levy,
        StandingArmy,
        Elite
    }
}
