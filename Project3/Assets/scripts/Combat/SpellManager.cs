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

    public void CallAbility(string abilityName, GameObject origin, GameObject otherCreature, List<float> values)
    {
        switch (abilityName)
        {
            case "PistolShot":
                PistolShot(origin, otherCreature, values[0]);
                break;
            case "StaffAttack":
                StaffAttack(otherCreature, values[0]);
                break;
            default:
                break;
        }

    }
    /// <summary>
    /// deals basic amounts of damage with fisty boys
    /// </summary>
    /// <param name="otherCreature"></param>
    /// <param name="attackMod"></param>
    public void BasicAttack(GameObject otherCreature, float attackMod)
    {
        Creature otherStats = otherCreature.GetComponent<Creature>();
        otherStats.CurrentHealth -= (int)(6 * attackMod);
    }
    /// <summary>
    /// reduces ammo of the person casting this
    /// deals big damage
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="otherCreature"></param>
    /// <param name="attackMod"></param>
    public void PistolShot(GameObject origin, GameObject otherCreature, float attackMod)
    {
        Creature otherStats = otherCreature.GetComponent<Creature>();
        otherStats.CurrentHealth -= (int)(10 * attackMod);
        origin.GetComponent<Creature>().Ammo--;
    }
    /// <summary>
    /// deals medium damage with a staffy boys
    /// </summary>
    /// <param name="otherCreature"></param>
    /// <param name="attackMod"></param>
    public void StaffAttack(GameObject otherCreature, float attackMod)
    {
        Creature otherStats = otherCreature.GetComponent<Creature>();
        otherStats.CurrentHealth -= (int)(8 * attackMod);
    }
}
