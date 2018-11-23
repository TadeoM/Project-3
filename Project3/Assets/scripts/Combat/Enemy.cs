using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature {
    int currentStage;
    List<string> knownAbilityNames;
    private void Start()
    {
        foreach (var ability in knownAbilities)
        {
            knownAbilityNames.Add(ability.Key);
        }
    }
    /// <summary>
    /// changes the stage based on the percentage of health it has
    /// </summary>
    override public int CurrentHealth
    {
        get { return base.CurrentHealth; }
        set {
            if (CurrentHealth / MaxHealth > .7)
            {
                currentStage = 1;
            }
            else if (CurrentHealth / MaxHealth <= .7)
            {
                currentStage = 2;
            }
            else if(CurrentHealth / MaxHealth <= .3)
            {
                currentStage = 3;
            }
            CurrentHealth = value;
        }
    }

    /// <summary>
    /// gets a random ability that the creature can use
    /// </summary>
    /// <returns></returns>
    public string GetChoice()
    {
        int randomChoice = Random.Range(0, knownAbilityNames.Count);
        currentAbilityChoice = knownAbilityNames[randomChoice];
        if (knownAbilities[currentAbilityChoice] > currentStage)
        {
            GetChoice();
        }
        return currentAbilityChoice;
    }
}
