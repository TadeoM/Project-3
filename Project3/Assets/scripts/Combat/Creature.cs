using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {

    // declare attributes
    public string currentAbilityChoice;
    public Dictionary<string, int> knownAbilities = new Dictionary<string, int>(); // the string contains the name, and the int is in what 'phase' the creature can use the ability
    public SpellManager spellManager;
    public GameObject currentTarget;
    public Stats stats;
    private int level;
    private int nextLevelXP;
    private int experience;
    private int maxHealth;
    private int maxMana;
    private int ammo;
    public int currentHealth;
    private int currentMana;

    public int CurrentMana
    {
        get { return currentMana; }
        set { currentMana = value; }
    }

    // properties
    public float Attack { get; set; }
    public float Defense { get; set; }
    public int Speed { get; set; }
    private string[] abilities;

    // full properties
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
    public int Ammo
    {
        get { return ammo; }
        set { ammo = value; }
    }
    /// <summary>
    /// set values from the stats attached to it
    /// </summary>
    public void Awake()
    {
        spellManager = GameObject.FindGameObjectWithTag("spellManager").GetComponent<SpellManager>();
        nextLevelXP = 100;
        maxHealth = stats.health;
        maxMana = stats.mana;
        ammo = stats.ammo;
        Defense = stats.defense;
        Attack = stats.attack;
        Speed = (int)stats.speed;
        currentHealth = MaxHealth;
        currentMana = MaxMana;
        foreach (var ability in stats.abilityNames)
        {
            knownAbilities.Add(ability, 0);
        }
    }
    // continues to add levels until it does not have enough experience to level up again
    public void IncreaseExperience()
    {
        
        bool checkedLevel = false;

        while (checkedLevel)
        {
            if (experience >= nextLevelXP)
            {
                level++;
                nextLevelXP += 100;
            }
            else
            {
                checkedLevel = true;
            }
        }
    }
    /// <summary>
    /// take thhe current ability choice and pass in the values needed to perform the attack
    /// </summary>
    public string SelectAttackChoice()
    {
        //Debug.Log(this.gameObject.name);
        string[] neededStats = spellManager.abilitiesDictionary[currentAbilityChoice];
        List<float> stats = new List<float>();
        for (int i = 0; i < neededStats.Length; i++)
        {
            switch (neededStats[i])
            {
                case "damage":
                    stats.Add(Attack);
                    break;
                case "defense":
                    stats.Add(Defense);
                    break;
                case "health":
                    stats.Add(currentHealth);
                    break;
                case "mana":
                    stats.Add(currentMana);
                    break;
                case "speed":
                    stats.Add(Speed);
                    break;
                default:
                    break;
            }
        }
        
        return spellManager.CallAbility(currentAbilityChoice, this.gameObject, currentTarget, stats);
    }
    virtual public string GetChoice() { return "This is the creature GetChoice"; }
    
    public bool CheckDeath()
    {
        Debug.Log(this.gameObject.name + "  CURRENT HEALTH IS " + currentHealth);
        if (currentHealth <= 0)
            return true;
        else
            return false;
    }
}
