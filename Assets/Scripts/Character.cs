using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Weapon
{
    public string name;
    public int damage;
    public float range;
    public Weapon(string name, int damage, float range)
    {
        this.name = name;
        this.damage = damage;
        this.range = range;
    }
    public void PrintWeaponStats()
    {
        Debug.LogFormat("Weapon - {0}, damage - {1}, range - {2}", name, damage, range);
    }
}
public class Character
{
    // misc
    public string name;
    public int exp = 0;

    //liveability stats
    public int maxHealth;
    public int health;
    public int maxEnergy;
    public int energy;
    // combat stats
    public int pushCooldown;
    public bool isHoldingSpear;

    public int bumpDamage = 1;

    public Character()
    {
        name = "Not assigned";
    }
    public Character(string name)
    {
        this.name = name;
    }

    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("Hero : {0} - {1} EXP", name, exp);
    }
    void Reset()
    {
        name = "Not assigned";
        exp = 0;
    }
}
