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
    public double attack;
    public double magic;
    public double defense;
    public double resistance;
    public double speed;
    public double experience;
    public List<string> abilityNames;
    public List<int> phaseUseable;
}
