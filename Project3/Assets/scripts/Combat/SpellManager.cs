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

    public string CallAbility(string abilityName, GameObject origin, GameObject otherCreature, List<float> values)
    {
        string whatHappened;
        switch (abilityName)
        {
            case "PistolShot":
                whatHappened = PistolShot(origin, otherCreature, values[0]);
                break;
            case "StaffAttack":
                whatHappened = StaffAttack(origin, otherCreature, values[0]);
                break;
            case "BasicAttack":
                whatHappened = StaffAttack(origin, otherCreature, values[0]);
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
    /// <param name="otherCreature"></param>
    /// <param name="attackMod"></param>
    public string BasicAttack(GameObject origin, GameObject otherCreature, float attackMod)
    {
        Creature otherStats = otherCreature.GetComponent<Creature>();
        int damage = (int)(6 * attackMod);
        otherStats.currentHealth -= damage;
        return origin.name + " did " + damage + " damage to " + otherCreature.name;
    }
    /// <summary>
    /// reduces ammo of the person casting this
    /// deals big damage
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="otherCreature"></param>
    /// <param name="attackMod"></param>
    public string PistolShot(GameObject origin, GameObject otherCreature, float attackMod)
    {
        Creature otherStats = otherCreature.GetComponent<Creature>();
        int damage = (int)(10 * attackMod);
        otherStats.currentHealth -= damage;
        origin.GetComponent<Creature>().Ammo--;
        return origin.name + " used 1 ammo to deal " + damage + " damage to " + otherCreature.name;
    }
    /// <summary>
    /// deals medium damage with a staffy boys
    /// </summary>
    /// <param name="otherCreature"></param>
    /// <param name="attackMod"></param>
    public string StaffAttack(GameObject origin, GameObject otherCreature, float attackMod)
    {
        Creature otherStats = otherCreature.GetComponent<Creature>();
        int damage = (int)(8 * attackMod);
        otherStats.currentHealth -= (int)(8 * attackMod);
        return origin.name + " did " + damage + " damage to " + otherCreature.name;
    }
}
