using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability", order = 1)]
public class Ability : ScriptableObject {

    public string abilityName;
    public string description;
    public bool debuffEnemy;
    public bool buffEnemy;
    public bool buffSelf;
    public bool debuffSelf;
    public int damage;
    public int manaRemoval;
    public int manaRequired;
    public int ammoRequired;
    public int healthGain;
    public int healthDrain;
    public float damageBuff;
    public float damageDebuff;
    public float defenseBuff;
    public float defenseDebuff;
    public float speedBuff;
    public float speedDebuff;
}
