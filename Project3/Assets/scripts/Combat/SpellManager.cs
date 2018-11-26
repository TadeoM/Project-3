using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour {
    public Dictionary<string, string[]> abilitiesDictionary = new Dictionary<string, string[]>();

    private void Start()
    {
        abilitiesDictionary.Add("BasicAttack", new string[1] { "damage" });
        abilitiesDictionary.Add("PistolShot", new string[1] { "damage" });
        abilitiesDictionary.Add("StaffAttack", new string[1] { "damage" });
    }

    public string CallAbility(string abilityName, GameObject origin, GameObject target, List<float> values)
    {
        string whatHappened;
        switch (abilityName)
        {
            case "PistolShot":
                whatHappened = PistolShot(origin, target, values[0]);
                break;
            case "StaffAttack":
                whatHappened = StaffAttack(origin, target, values[0]);
                break;
            case "BasicAttack":
                whatHappened = StaffAttack(origin, target, values[0]);
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
    public string BasicAttack(GameObject origin, GameObject target, float attackMod)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(10);
        otherStats.currentHealth -= damage;
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    /// <summary>
    /// reduces ammo of the person casting this
    /// deals big damage
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <param name="attackMod"></param>
    public string PistolShot(GameObject origin, GameObject target, float attackMod)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Debug.Log(attackMod);
        int damage = (int)(15);
        otherStats.currentHealth -= damage;
        origin.GetComponent<Creature>().Ammo--;
        return origin.name + " used 1 ammo to deal " + damage + " damage to " + target.name;
    }
    /// <summary>
    /// deals medium damage with a staffy boys
    /// </summary>
    /// <param name="target"></param>
    /// <param name="attackMod"></param>
    public string StaffAttack(GameObject origin, GameObject target, float attackMod)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(10);
        otherStats.currentHealth -= damage;
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Fuego(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }

    /// <summary>
    /// stuff below needs changing
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public string CircleOfFire(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        Creature originStats = origin.GetComponent<Creature>();
        originStats.Attack *= 1.3f;
        return origin.name + " increased it's attack by 30%!";
    }
    public string COfIron(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string EnforceGuard(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Fortius(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Defendarius(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Slash(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Fortify(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Swipe(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Siphon(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Screech(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Bite(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Scorch(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Howl(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Scratch(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string VamprieBite(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
    public string Feast(GameObject origin, GameObject target)
    {
        Creature otherStats = target.GetComponent<Creature>();
        int damage = (int)(20);
        otherStats.currentHealth -= (int)(damage);
        return origin.name + " did " + damage + " damage to " + target.name;
    }
}
