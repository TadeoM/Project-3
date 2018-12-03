using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {

    // declare attributes
    public string currentAbilityChoice;
    public Dictionary<string, int> knownAbilities = new Dictionary<string, int>(); // the string contains the name, and the int is in what 'phase' the creature can use the ability
    public Dictionary<string, double[]> statusEffects; // key is the stat being affected, first double is for how much the stat is affected by, and the second double is for how long
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
    public float Magic { get; set; }
    public float Resistance { get; set; }
    public float Defense { get; set; }
    public float Speed { get; set; }
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
        level = stats.level;
        maxHealth = stats.health;
        maxMana = stats.mana;
        ammo = stats.ammo;
        Magic = stats.magic;
        Defense = stats.defense;
        Attack = stats.attack;
        Speed = (int)stats.speed;
        Resistance = stats.resistance;
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
                maxHealth = (int)(MaxHealth * level) / 2;
                maxMana = (int)(maxMana + level);
                Attack = (int)(Attack * level) / 3;
                Magic = (int)(Magic * level) / 3;
                Defense = (int)(Defense * level) / 3;
                Resistance = (int)(Resistance * level) / 3;
                Speed = (int)(Speed * level) / 3;
            }
            else
            {
                checkedLevel = true;
            }
        }
    }
    /// <summary>
    /// take the current ability choice and pass in the values needed to perform the attack
    /// </summary>
    public string SelectAttackChoice()
    {
        //Debug.Log(currentAbilityChoice);

        int[] neededResource = spellManager.abilitiesDictionary[currentAbilityChoice];
        if(neededResource[0] > ammo)
        {
            return "Could not use ability due to not having enough ammo";
        }
        else if (neededResource[1] > currentMana)
        {
            return "Could not use ability due to not having enough mana";
        }
        
        
        return spellManager.CallAbility(currentAbilityChoice, this.gameObject, currentTarget);
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

    public void TakeDamage(float damage, string type)
    {
        Debug.Log("Damage done: " + damage);
        currentHealth -= Mathf.FloorToInt(damage);
    }
}
