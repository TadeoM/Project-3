using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {

    // declare attributes
    private int level;
    private int experience;
    private int maxHealth;
    private int maxMana;

    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Speed { get; set; }
    private string[] abilities;

    public int Level
    {
        get { return level; }
    }
    public int Experience
    {
        get { return experience; }
        set { experience = value; }
    }
    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }
    public int MaxMana
    {
        get { return maxMana; }
        set { maxMana = value; }
    }

    void GetAttackChoice()
    {
    }

    void DealDamage(GameObject otherCreature)
    {

    }


}
