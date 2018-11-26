using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Stats", menuName = "Stats", order = 1)]
public class Stats : ScriptableObject
{
    public string name;
    public int health;
    public int mana;
    public int ammo;
    public float attack;
    public float defense;
    public float speed;
    public List<string> abilityNames;
    public List<int> phaseUseable;
}
