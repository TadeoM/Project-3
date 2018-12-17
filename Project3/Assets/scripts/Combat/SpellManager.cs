using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour {
    public Dictionary<string, int[]> abilitiesDictionary = new Dictionary<string, int[]>();

    private void Start()
    {
        //Dresden
        abilitiesDictionary.Add("Attack", new int[2] { 0, 0 });
        abilitiesDictionary.Add("PistolShot", new int[2] { 1, 0 });
        abilitiesDictionary.Add("Defendarius", new int[2] { 0, 2 });
        abilitiesDictionary.Add("Fuego", new int[2] { 0, 3 });
        abilitiesDictionary.Add("CircleOfFire", new int[2] { 0, 3 });
        abilitiesDictionary.Add("COfIron", new int[2] { 0, 3 });
        abilitiesDictionary.Add("EnfeebleAttack", new int[2] { 0, 3 });
        abilitiesDictionary.Add("EnfeebleGuard", new int[2] { 0, 3 });
        abilitiesDictionary.Add("Fortius", new int[2] { 0, 4 });

        //Ghoul
        abilitiesDictionary.Add("Siphon", new int[2] { 0, 5 });
        abilitiesDictionary.Add("Swipe", new int[2] { 0, 0 });
        abilitiesDictionary.Add("Screech", new int[2] { 0, 5 });

        //Hellhound
        abilitiesDictionary.Add("Howl", new int[2] { 0, 5 });
        abilitiesDictionary.Add("Scorch", new int[2] { 0, 5 });
        abilitiesDictionary.Add("Bite", new int[2] { 0, 0 });

        //Goblin
        abilitiesDictionary.Add("Fortify", new int[2] { 0, 5 });
        abilitiesDictionary.Add("Slash", new int[2] { 0, 0 });

        //Vampire
        abilitiesDictionary.Add("Scratch", new int[2] { 0, 0 });
        abilitiesDictionary.Add("Devour", new int[2] { 0, 10 });
        abilitiesDictionary.Add("Feast", new int[2] { 0, 0 });


    }

    public string CallAbility(string abilityName, GameObject origin, GameObject target)
    {
        string whatHappened;
        switch (abilityName)
        {
            case "PistolShot":
                whatHappened = PistolShot(origin, target);
                break;
            case "Fuego":
                whatHappened = Fuego(origin, target);
                break;
            case "Attack":
                whatHappened = Attack(origin, target);
                break;
            case "Defendarius":
                whatHappened = Defendarius(origin, target);
                break;
            case "CircleOfFire":
                whatHappened = CircleOfFire(origin, target);
                break;
            case "COfIron":
                whatHappened = COfIron(origin, target);
                break;
            case "EnfeebleAttack":
                whatHappened = EnfeebleAttack(origin, target);
                break;
            case "EnfeebleGuard":
                whatHappened = EnfeebleGuard(origin, target);
                break;
            case "Fortius":
                whatHappened = Fortius(origin, target);
                break;
            case "Swipe":
                whatHappened = Swipe(origin, target);
                break;
            case "Siphon":
                whatHappened = Siphon(origin, target);
                break;
            case "Screech":
                whatHappened = Screech(origin, target);
                break;
            case "Bite":
                whatHappened = Bite(origin, target);
                break;
            case "Scorch":
                whatHappened = Scorch(origin, target);
                break;
            case "Howl":
                whatHappened = Howl(origin, target);
                break;
            case "Slash":
                whatHappened = Slash(origin, target);
                break;
            case "Fortify":
                whatHappened = Fortify(origin, target);
                break;
            case "Feast":
                whatHappened = Feast(origin, target);
                break;
            case "Scratch":
                whatHappened = Scratch(origin, target);
                break;
            case "Devour":
                whatHappened = Devour(origin, target);
                break;
            default:
                whatHappened = "Nothing";
                break;
        }
        return whatHappened;
    }
    /// <summary>
    /// deals basic amounts of damage with fisty boys
    /// </summary>
    /// <param name="target"></param>
    /// <param name="attackMod"></param>
    public string Attack(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();
        Debug.Log("ATTACK");
        float damage = CalcPhsyical(originStats, otherStats, 10.0f);
        otherStats.TakeDamage(damage, "physical");

        return origin.name + " did " + damage + " physical damage to " + target.name;
    }
    /// <summary>
    /// reduces ammo of the person casting this
    /// deals big damage
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <param name="attackMod"></param>
    public string PistolShot(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();
        float damage = CalcPhsyical(originStats, otherStats, 15.0f);


        otherStats.TakeDamage(damage, "physical");
        origin.GetComponent<Creature>().Ammo--;

        return origin.name + " used 1 ammo to deal " + damage + " physical damage to " + target.name;
    }

    /// <summary>
    /// Set damage of the next enemy attack to 0 (use a bool in Creature class)
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Defendarius(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        origin.GetComponent<Creature>().CurrentMana -= 2;
        return origin.name + " did something???";
    }

    /// <summary>
    /// Deals big damage 
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Fuego(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        float damage = CalcMagical(originStats, otherStats, 20.0f);

        otherStats.TakeDamage(damage, "magical");
        origin.GetComponent<Creature>().CurrentMana -= 5;
        return origin.name + " did " + damage + " magical damage to " + target.name;
    }

    /// <summary>
    /// increases attack and magic by 1.3
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string CircleOfFire(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        originStats.CurrentMana -= 3;
        originStats.Attack *= 1.3f;
        originStats.Magic *= 1.3f;
        originStats.statusEffects.Add("attack", new double[2] { 1.3, 2 });
        originStats.statusEffects.Add("magic", new double[2] { 1.3, 2 });

        return origin.name + " increased it's attack and magic by 30%!";
    }

    /// <summary>
    /// increases defense and resistance by 1.3
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string COfIron(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        originStats.CurrentMana -= 3;
        originStats.Defense *= 1.3f;
        originStats.Resistance *= 1.3f;
        originStats.statusEffects.Add("defense", new double[2] { 1.3, 2 });
        originStats.statusEffects.Add("resistance", new double[2] { 1.3, 2 });

        return origin.name + " increased it's defense and resistance by 30%!";
    }

    /// <summary>
    /// decreases target's attack and magic by 30%
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string EnfeebleAttack(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        originStats.CurrentMana -= 3;
        otherStats.Attack *= 0.7f;
        otherStats.Magic *= 0.7f;
        //otherStats.statusEffects.Add("attack", new double[2] { 0.7, 2 });
       // otherStats.statusEffects.Add("magic", new double[2] { 0.7, 2 });

        return origin.name + " decreased " + otherStats.name + "'s attack and magic by 30%!";
    }

    /// <summary>
    /// decreases target's defense and resistance
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string EnfeebleGuard(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        originStats.CurrentMana -= 3;
        otherStats.Defense *= 0.7f;
        otherStats.Resistance *= 0.7f;
        //otherStats.statusEffects.Add("defense", new double[2] { 0.7, 2 });
       // otherStats.statusEffects.Add("resistance", new double[2] { 0.7, 2 });

        return origin.name + " decreased " + otherStats.name + "'s defense and resistance by 30%!";
    }

    /// <summary>
    /// restores caster's HP by 25% of max HP
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Fortius(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        otherStats.CurrentMana -= 4;
        otherStats.currentHealth += (int)(originStats.MaxHealth * 0.25);

        return origin.name + " restored its HP!";
    }

    /// <summary>
    /// deals 15 physical to target
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Slash(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        float damage = CalcPhsyical(originStats, otherStats, 15.0f);

        otherStats.TakeDamage(damage, "physical");

        return origin.name + " did " + damage + " physical damage to " + target.name;
    }

    /// <summary>
    /// increases target's defense by 25%
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Fortify(GameObject origin, GameObject target)
    {
        Creature originStats = origin.GetComponent<Creature>();

        originStats.CurrentMana -= 5;
        originStats.Defense *= 1.25f;
        originStats.statusEffects.Add("defense", new double[2] { 1.25, 2 });

        return origin.name + " increased its defense";
    }

    /// <summary>
    /// deals 15 phyiscal to target
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Swipe(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();
        float damage = CalcPhsyical(originStats, otherStats, 15.0f);

        otherStats.TakeDamage(damage, "physical");
       
        return origin.name + " did " + damage + " phyiscal damage to " + target.name;
    }

    /// <summary>
    /// caster heals damage and target takes 15 magical
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Siphon(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();
        
        float damage = CalcMagical(originStats, otherStats,15.0f);

        otherStats.TakeDamage(damage, "magical");
        originStats.CurrentMana -= 5;

        originStats.currentHealth += (int)(originStats.MaxHealth * .25);

        return origin.name + " did " + damage + " magical damage to " + target.name + " and restored its health";
    }

    /// <summary>
    /// decreases target's defense
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Screech(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        originStats.CurrentMana -= 5;
        otherStats.Defense = (int)(otherStats.Defense * .75);
        otherStats.statusEffects.Add("defense", new double[2] { .75, 2 });

        return target.name + "'s defense was lowered!";
    }
    
    /// <summary>
    /// deals 15 physical to target
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Bite(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        float damage = CalcPhsyical(originStats, otherStats, 15.0f);

        otherStats.TakeDamage(damage, "physical");
        
        return origin.name + " did " + damage + " phyical damage to " + target.name;
    }

    /// <summary>
    /// deals 15 magical to target
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Scorch(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();
        float damage = CalcMagical(originStats, otherStats, 15.0f);

        otherStats.TakeDamage(damage, "magical");
        originStats.CurrentMana -= 5;
        return origin.name + " did " + damage + " magical damage to " + target.name;
    }
    /// <summary>
    /// increases caster's attack and magic
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Howl(GameObject origin, GameObject target)
    {
        Creature originStats = origin.GetComponent<Creature>();

        originStats.CurrentMana -= 5;

        originStats.Attack *= 1.25f;
        originStats.Magic *= 1.25f;

        originStats.statusEffects.Add("attack", new double[2] { 1.25, 2 });
        originStats.statusEffects.Add("magic", new double[2] { 1.25, 2 });

        return origin.name + " increased its attack and magic!";
    }
    
    /// <summary>
    /// deals 25 phyiscal to target
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Scratch(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        float damage = CalcPhsyical(originStats, otherStats, 25.0f);

        otherStats.TakeDamage(damage, "physical");

        return origin.name + " did " + damage + " physical damage to " + target.name;
    }

    /// <summary>
    /// decreases target's defense and resistance and deals 15 physical 
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Devour(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        originStats.CurrentMana -= 10;
        float damage = (int)(originStats.Attack * 15);

        otherStats.TakeDamage(damage, "physical");
        otherStats.Defense *= 0.7f;
        otherStats.Resistance *= 0.7f;

        originStats.statusEffects.Add("defense", new double[2] { 0.7, 2 });
        originStats.statusEffects.Add("resistance", new double[2] { 0.7, 2 });

        return origin.name + " did " + damage + " physical damage to " + target.name + " and decreased its defense and resistance!";
    }

    /// <summary>
    /// heals caster for 30% max health and deals 30 magical
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string Feast(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();

        float damage = CalcMagical(originStats, otherStats, 30.0f);

        otherStats.TakeDamage(damage, "magical");
        originStats.currentHealth += (int)(originStats.MaxHealth * 0.3);
        
        return origin.name + " did " + damage + " magical damage to " + target.name + " and healed itself!";
    }

    public float CalcPhsyical(Creature origin, Creature target,float baseDamage)
    {
        return ((origin.Attack * baseDamage) / (target.Defense * (origin.Level / 2.0f)))/2.0f;
    }

    public float CalcMagical(Creature origin, Creature target, float baseDamage)
    {

        return ((origin.Magic * baseDamage) / (target.Resistance * (origin.Level / 2.0f)))/2.0f;
    }
}
