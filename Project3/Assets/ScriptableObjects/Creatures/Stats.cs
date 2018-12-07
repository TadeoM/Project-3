using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Stats", menuName = "Stats", order = 1)]
public class Stats : ScriptableObject
{
    public int health;
    public int mana;
    public int ammo;
    public int level;
    public float attack;
    public float magic;
    public float defense;
    public float resistance;
    public float speed;
    public float experience;
    public List<string> abilityNames;
    public List<int> phaseUseable;
}
