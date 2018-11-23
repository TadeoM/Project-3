using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {

    // declare attributes
    public int currentHealth;
    public int currentMana;
    public List<Ability> knownAbilities;
    private int level;
    private int nextLevelXP;
    private int experience;
    private int maxHealth;
    private int maxMana;

    public float Attack { get; set; }
    public float Defense { get; set; }
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
    }
    public int MaxMana
    {
        get { return maxMana; }
    }

    public void IncreasExperience()
    {
        bool checkedLevel = false;

        while (checkedLevel)
        {
            if (experience >= nextLevelXP)
            {
                level++;
            }
            else
            {
                checkedLevel = true;
            }
        }
    }

    void GetAttackChoice()
    {
    }

    virtual public void OffensiveAbility(GameObject otherCreature, Ability attack)
    {
        Creature creatureStats = otherCreature.GetComponent<Creature>();
        currentMana -= attack.manaRequired;
        creatureStats.currentHealth -= attack.damage;
        creatureStats.currentMana -= attack.manaRemoval;
        creatureStats.Defense = creatureStats.Defense * attack.defenseDebuff;

    }
    virtual public void DefensiveAbility(Ability ability)
    {

    }


}
