using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {

    // declare attributes
    public string currentAbilityChoice;
    public Dictionary<string, int> knownAbilities = new Dictionary<string, int>(); // the string contains the name, and the int is in what 'phase' the creature can use the ability
    public Dictionary<string, double[]> statusEffects = new Dictionary<string, double[]>(); // key is the stat being affected, first double is for how much the stat is affected by, and the second double is for how long
    public SpellManager spellManager;
    public GameObject currentTarget;
    public Stats stats;
    public Animator animator;
    public int currentAnimation; // 0 = idle, 1 = attack, 2 = damaged
    public Vector3 startPos;
    public Vector3 endPos; 
    public int level;
    public int nextLevelXP;
    private int maxHealth;
    private int maxMana;
    private int maxAmmo;
    private int ammo;
    public int currentHealth;
    public int currentMana;
    private int baseHealth;
    private int baseMana;
    private float baseAttack;
    private float baseMagic;
    private float baseDefense;
    private float baseRes;
    private float baseSpeed;
    private float experience;
    public int previousAnimation;


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
    public float Experience
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
    public int Ammo
    {
        get { return ammo; }
        set { ammo = value; }
    }
    public int MaxAmmo
    {
        get { return maxAmmo; }
        set { maxAmmo = value; }
    }
    /// <summary>
    /// set values from the stats attached to it
    /// </summary>
    public void Awake()
    {
        spellManager = GameObject.FindGameObjectWithTag("spellManager").GetComponent<SpellManager>();
        nextLevelXP = 25;
        level = stats.level;
        maxHealth = stats.health;
        maxMana = stats.mana;
        maxAmmo = stats.ammo;
        ammo = maxAmmo;
        Magic = stats.magic;
        Defense = stats.defense;
        Attack = stats.attack;
        Speed = (int)stats.speed;
        Resistance = stats.resistance;
        currentHealth = MaxHealth;
        currentMana = MaxMana;
        experience = stats.experience;

        baseHealth = stats.health;
        baseMana = stats.mana;
        baseAttack = stats.attack;
        baseDefense = stats.defense;
        baseRes = stats.resistance;
        baseMagic = stats.magic;
        baseSpeed = stats.speed;

        foreach (var ability in stats.abilityNames)
        {
            knownAbilities.Add(ability, 0);
        }
        currentAnimation = 0;
        previousAnimation = 0;
    }

    virtual public void Update()
    {
        if (CurrentMana < 0)
            CurrentMana = 0;
    }

    // continues to add levels until it does not have enough experience to level up again
    public void IncreaseExperience(float xp)
    {
        experience += xp;
        Debug.Log("Dresden gained " + xp + " and his experience is now: " + experience);
        if (Level != 10)
        {
            if (experience >= nextLevelXP)
            {
                level++;
                nextLevelXP += 50;
                MaxHealth += (int)(baseHealth * level) / 3;
                MaxMana += (int)(level);
                Attack += (int)(baseAttack * level) / 4;
                Magic += (int)(baseMagic * level) / 4;
                Defense += (int)(baseDefense * level) / 4;
                Resistance += (int)(baseRes * level) / 4;
                Speed += (int)(baseSpeed * level) / 4;
                Debug.Log(Attack);
                if(name.Contains("Dresdon"))
                {
                    GetComponent<AudioSource>().Play();
                }
            }
        }

        if(GetComponent<Animator>() != null)
        {
            animator = GetComponent<Animator>();
        }
        else
        {
            animator = GetComponentInChildren<Animator>();
        }
    }
    /// <summary>
    /// take the current ability choice and pass in the values needed to perform the attack
    /// </summary>
    virtual public string SelectAttackChoice()
    {
        int[] neededResource = spellManager.abilitiesDictionary[currentAbilityChoice];
        if(neededResource[0] > ammo)
        {
            return "Could not use ability due to not having enough ammo";
        }
        else if (neededResource[1] > currentMana)
        {
            return "Could not use ability due to not having enough mana";
        }

        currentAnimation = 1;
        return spellManager.CallAbility(currentAbilityChoice, this.gameObject, currentTarget);
    }
    virtual public string GetChoice() { return "This is the creature GetChoice"; }
    
    public bool CheckDeath()
    {
        //Debug.Log(this.gameObject.name + "  CURRENT HEALTH IS " + currentHealth);
        if (currentHealth <= 0)
            return true;
        else
            return false;
    }

    public void TakeDamage(float damage, string type)
    {
        //Debug.Log("Damage done: " + damage);
        currentHealth -= Mathf.FloorToInt(damage);
    }
    
    public void ChangeAnimation(int anim)
    {
        animator.SetInteger("animation", anim);
        previousAnimation = anim;
    }
}